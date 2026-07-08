using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asERP.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesChannelSyncState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bic",
                table: "tenant",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "tenant",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "tenant",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VatId",
                table: "tenant",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "saleschannel_sync_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InitialProductImportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    InitialProductExportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    InitialCustomerImportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    InitialSalesImportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SalesImportBackfillCursor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerImportPageCursor = table.Column<int>(type: "int", nullable: false),
                    LastSyncStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleschannel_sync_state", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saleschannel_sync_state_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Preserve existing per-channel sync progress: copy the columns about to be dropped from
            // saleschannel into the new (token-free) saleschannel_sync_state BEFORE dropping them, so a
            // running order backfill / product / customer import resumes instead of restarting from scratch.
            // The demo POS channel is seeded separately below and excluded here to avoid a duplicate row.
            migrationBuilder.Sql(@"
                INSERT INTO saleschannel_sync_state
                    ([Id],[SalesChannelId],[InitialProductImportCompleted],[InitialProductExportCompleted],
                     [InitialCustomerImportCompleted],[InitialSalesImportCompleted],[SalesImportBackfillCursor],
                     [CustomerImportPageCursor],[LastSyncStartedAt],[DateCreated],[DateModified],[TenantId])
                SELECT NEWID(), sc.[Id], sc.[InitialProductImportCompleted], sc.[InitialProductExportCompleted],
                       sc.[InitialCustomerImportCompleted], sc.[InitialSalesImportCompleted], sc.[SalesImportBackfillCursor],
                       sc.[CustomerImportPageCursor], sc.[LastSyncStartedAt], SYSUTCDATETIME(), SYSUTCDATETIME(), sc.[TenantId]
                FROM saleschannel sc
                WHERE sc.[Id] <> '88888888-8888-8888-8888-888888888888'
                  AND NOT EXISTS (SELECT 1 FROM saleschannel_sync_state ss WHERE ss.[SalesChannelId] = sc.[Id]);
            ");

            migrationBuilder.DropColumn(name: "CustomerImportPageCursor", table: "saleschannel");
            migrationBuilder.DropColumn(name: "InitialCustomerImportCompleted", table: "saleschannel");
            migrationBuilder.DropColumn(name: "InitialProductExportCompleted", table: "saleschannel");
            migrationBuilder.DropColumn(name: "InitialProductImportCompleted", table: "saleschannel");
            migrationBuilder.DropColumn(name: "InitialSalesImportCompleted", table: "saleschannel");
            migrationBuilder.DropColumn(name: "LastSyncStartedAt", table: "saleschannel");
            migrationBuilder.DropColumn(name: "SalesImportBackfillCursor", table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 456, DateTimeKind.Utc).AddTicks(9619), new DateTime(2026, 7, 8, 11, 10, 41, 456, DateTimeKind.Utc).AddTicks(9625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(384), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(387), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(392), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(394), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(406), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(408), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(411), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(413), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(414), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(416), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(427), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(431), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(432), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(434), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(436), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(437), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(442), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(443), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(444) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(461), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(479), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(481), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(483), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(484), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(486), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(498), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(507), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(509), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(511), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(512), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(514), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(515), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(517), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(519), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(521), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(523), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(524), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(526), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(527), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(529), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(530), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(538), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(539) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(542), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(543), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(545), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(547), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(548), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(550), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(551), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(553), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(557), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(557) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(558), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(559) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(560), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(561), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(563), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(563) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(564), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(565) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(566), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(566) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(574), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(574) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(577), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(578), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(580), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(582), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(583), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(585), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(586), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(591), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(592), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(594), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(595), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(595) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(597), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(598), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(599), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(607), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(611), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(613), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(615), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(616), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(618), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(619), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(619) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(621), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(622), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(622) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(625), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(626), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(627) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(628), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(629), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(631), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(632), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(645), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(646), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(648), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(650), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(651), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(654), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(656), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(659) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(662), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(665), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(666), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(675), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(678), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(683), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(684), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(686), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(686) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(687), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(693), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(698), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "CountryCode", "DateCreated", "DateModified", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000121"), "AE", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(699), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(699), "United Arab Emirates", null },
                    { new Guid("00000000-0000-0000-0000-000000000122"), "AI", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(701), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(701), "Anguilla", null },
                    { new Guid("00000000-0000-0000-0000-000000000123"), "AS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(702), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(702), "American Samoa", null },
                    { new Guid("00000000-0000-0000-0000-000000000124"), "AW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(704), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(704), "Aruba", null },
                    { new Guid("00000000-0000-0000-0000-000000000125"), "BD", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(705), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(705), "Bangladesh", null },
                    { new Guid("00000000-0000-0000-0000-000000000126"), "BF", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(713), "Burkina Faso", null },
                    { new Guid("00000000-0000-0000-0000-000000000127"), "BH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(718), "Bahrain", null },
                    { new Guid("00000000-0000-0000-0000-000000000128"), "BI", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(719), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(719), "Burundi", null },
                    { new Guid("00000000-0000-0000-0000-000000000129"), "BJ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(721), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(721), "Benin", null },
                    { new Guid("00000000-0000-0000-0000-000000000130"), "BM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(723), "Bermuda", null },
                    { new Guid("00000000-0000-0000-0000-000000000131"), "BN", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(724), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(724), "Brunei", null },
                    { new Guid("00000000-0000-0000-0000-000000000132"), "BQ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(725), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(726), "Bonaire, Sint Eustatius and Saba", null },
                    { new Guid("00000000-0000-0000-0000-000000000133"), "BT", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(727), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(727), "Bhutan", null },
                    { new Guid("00000000-0000-0000-0000-000000000134"), "BV", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(729), "Bouvet Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000135"), "BW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(731), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(731), "Botswana", null },
                    { new Guid("00000000-0000-0000-0000-000000000136"), "CD", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(733), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(733), "Democratic Republic of the Congo", null },
                    { new Guid("00000000-0000-0000-0000-000000000137"), "CF", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(735), "Central African Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000138"), "CG", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(736), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(736), "Republic of the Congo", null },
                    { new Guid("00000000-0000-0000-0000-000000000139"), "CK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(737), "Cook Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000140"), "CM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(739), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(739), "Cameroon", null },
                    { new Guid("00000000-0000-0000-0000-000000000141"), "CV", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(740), "Cape Verde", null },
                    { new Guid("00000000-0000-0000-0000-000000000142"), "CW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(748), "Curaçao", null },
                    { new Guid("00000000-0000-0000-0000-000000000143"), "CX", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(751), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(751), "Christmas Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000144"), "DJ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(753), "Djibouti", null },
                    { new Guid("00000000-0000-0000-0000-000000000145"), "DM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(755), "Dominica", null },
                    { new Guid("00000000-0000-0000-0000-000000000146"), "EH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(756), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(756), "Western Sahara", null },
                    { new Guid("00000000-0000-0000-0000-000000000147"), "FJ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(758), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(758), "Fiji", null },
                    { new Guid("00000000-0000-0000-0000-000000000148"), "FK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(759), "Falkland Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000149"), "FM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(761), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(761), "Micronesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000150"), "FO", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(763), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(763), "Faroe Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000151"), "GA", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(766), "Gabon", null },
                    { new Guid("00000000-0000-0000-0000-000000000152"), "GD", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(768), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(768), "Grenada", null },
                    { new Guid("00000000-0000-0000-0000-000000000153"), "GG", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(769), "Guernsey", null },
                    { new Guid("00000000-0000-0000-0000-000000000154"), "GI", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(771), "Gibraltar", null },
                    { new Guid("00000000-0000-0000-0000-000000000155"), "GM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(772), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(772), "Gambia", null },
                    { new Guid("00000000-0000-0000-0000-000000000156"), "GN", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(774), "Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000157"), "GQ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(775), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(775), "Equatorial Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000158"), "GS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(783), "South Georgia and the South Sandwich Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000159"), "GU", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(786), "Guam", null },
                    { new Guid("00000000-0000-0000-0000-000000000160"), "GW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(787), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(788), "Guinea-Bissau", null },
                    { new Guid("00000000-0000-0000-0000-000000000161"), "HK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(789), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(789), "Hong Kong", null },
                    { new Guid("00000000-0000-0000-0000-000000000162"), "HM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(791), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(791), "Heard Island and McDonald Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000163"), "IL", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(792), "Israel", null },
                    { new Guid("00000000-0000-0000-0000-000000000164"), "IM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(794), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(794), "Isle of Man", null },
                    { new Guid("00000000-0000-0000-0000-000000000165"), "IO", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(796), "British Indian Ocean Territory", null },
                    { new Guid("00000000-0000-0000-0000-000000000166"), "IQ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(797), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(797), "Iraq", null },
                    { new Guid("00000000-0000-0000-0000-000000000167"), "JE", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(800), "Jersey", null },
                    { new Guid("00000000-0000-0000-0000-000000000168"), "JO", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(801), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(801), "Jordan", null },
                    { new Guid("00000000-0000-0000-0000-000000000169"), "KH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(803), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(803), "Cambodia", null },
                    { new Guid("00000000-0000-0000-0000-000000000170"), "KI", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(805), "Kiribati", null },
                    { new Guid("00000000-0000-0000-0000-000000000171"), "KM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(806), "Comoros", null },
                    { new Guid("00000000-0000-0000-0000-000000000172"), "KN", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(807), "Saint Kitts and Nevis", null },
                    { new Guid("00000000-0000-0000-0000-000000000173"), "KP", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(809), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(809), "North Korea", null },
                    { new Guid("00000000-0000-0000-0000-000000000174"), "KY", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(817), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(818), "Cayman Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000175"), "LA", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(820), "Laos", null },
                    { new Guid("00000000-0000-0000-0000-000000000176"), "LB", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(822), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(822), "Lebanon", null },
                    { new Guid("00000000-0000-0000-0000-000000000177"), "LC", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(823), "Saint Lucia", null },
                    { new Guid("00000000-0000-0000-0000-000000000178"), "LI", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(825), "Liechtenstein", null },
                    { new Guid("00000000-0000-0000-0000-000000000179"), "LK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(826), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(827), "Sri Lanka", null },
                    { new Guid("00000000-0000-0000-0000-000000000180"), "LR", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(828), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(828), "Liberia", null },
                    { new Guid("00000000-0000-0000-0000-000000000181"), "LS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(830), "Lesotho", null },
                    { new Guid("00000000-0000-0000-0000-000000000182"), "LY", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(831), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(831), "Libya", null },
                    { new Guid("00000000-0000-0000-0000-000000000183"), "ME", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(834), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(834), "Montenegro", null },
                    { new Guid("00000000-0000-0000-0000-000000000184"), "MH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(835), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(835), "Marshall Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000185"), "MK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(837), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(837), "North Macedonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000186"), "ML", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(838), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(838), "Mali", null },
                    { new Guid("00000000-0000-0000-0000-000000000187"), "MM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(840), "Myanmar", null },
                    { new Guid("00000000-0000-0000-0000-000000000188"), "MN", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(841), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(841), "Mongolia", null },
                    { new Guid("00000000-0000-0000-0000-000000000189"), "MO", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(842), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(843), "Macao", null },
                    { new Guid("00000000-0000-0000-0000-000000000190"), "MP", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(851), "Northern Mariana Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000191"), "MR", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(854), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(854), "Mauritania", null },
                    { new Guid("00000000-0000-0000-0000-000000000192"), "MS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(855), "Montserrat", null },
                    { new Guid("00000000-0000-0000-0000-000000000193"), "MU", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(857), "Mauritius", null },
                    { new Guid("00000000-0000-0000-0000-000000000194"), "MV", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(858), "Maldives", null },
                    { new Guid("00000000-0000-0000-0000-000000000195"), "MW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(860), "Malawi", null },
                    { new Guid("00000000-0000-0000-0000-000000000196"), "MZ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(861), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(862), "Mozambique", null },
                    { new Guid("00000000-0000-0000-0000-000000000197"), "NA", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(864), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(864), "Namibia", null },
                    { new Guid("00000000-0000-0000-0000-000000000198"), "NC", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(866), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(866), "New Caledonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000199"), "NE", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(868), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(869), "Niger", null },
                    { new Guid("00000000-0000-0000-0000-000000000200"), "NF", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(870), "Norfolk Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000201"), "NP", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(872), "Nepal", null },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "NR", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(873), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(873), "Nauru", null },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "NU", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(875), "Niue", null },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "PF", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(876), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(876), "French Polynesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000205"), "PG", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(877), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(877), "Papua New Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000206"), "PH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(885), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(885), "Philippines", null },
                    { new Guid("00000000-0000-0000-0000-000000000207"), "PK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(888), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(888), "Pakistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000208"), "PN", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(890), "Pitcairn Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000209"), "PS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(892), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(892), "Palestine", null },
                    { new Guid("00000000-0000-0000-0000-000000000210"), "PW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(893), "Palau", null },
                    { new Guid("00000000-0000-0000-0000-000000000211"), "RE", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(900), "Réunion", null },
                    { new Guid("00000000-0000-0000-0000-000000000212"), "RW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(902), "Rwanda", null },
                    { new Guid("00000000-0000-0000-0000-000000000213"), "SB", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(903), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(903), "Solomon Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000214"), "SC", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(905), "Seychelles", null },
                    { new Guid("00000000-0000-0000-0000-000000000215"), "SD", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(907), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(908), "Sudan", null },
                    { new Guid("00000000-0000-0000-0000-000000000216"), "SH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(909), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(909), "Saint Helena", null },
                    { new Guid("00000000-0000-0000-0000-000000000217"), "SJ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(911), "Svalbard and Jan Mayen", null },
                    { new Guid("00000000-0000-0000-0000-000000000218"), "SL", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(912), "Sierra Leone", null },
                    { new Guid("00000000-0000-0000-0000-000000000219"), "SM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(914), "San Marino", null },
                    { new Guid("00000000-0000-0000-0000-000000000220"), "SO", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(915), "Somalia", null },
                    { new Guid("00000000-0000-0000-0000-000000000221"), "SS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(917), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(917), "South Sudan", null },
                    { new Guid("00000000-0000-0000-0000-000000000222"), "ST", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(925), "São Tomé and Príncipe", null },
                    { new Guid("00000000-0000-0000-0000-000000000223"), "SX", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(928), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(928), "Sint Maarten", null },
                    { new Guid("00000000-0000-0000-0000-000000000224"), "SY", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(930), "Syria", null },
                    { new Guid("00000000-0000-0000-0000-000000000225"), "SZ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(932), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(932), "Eswatini", null },
                    { new Guid("00000000-0000-0000-0000-000000000226"), "TC", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(934), "Turks and Caicos Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000227"), "TD", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(935), "Chad", null },
                    { new Guid("00000000-0000-0000-0000-000000000228"), "TF", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(937), "French Southern Territories", null },
                    { new Guid("00000000-0000-0000-0000-000000000229"), "TG", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(938), "Togo", null },
                    { new Guid("00000000-0000-0000-0000-000000000230"), "TH", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(939), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(940), "Thailand", null },
                    { new Guid("00000000-0000-0000-0000-000000000231"), "TJ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(942), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(942), "Tajikistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000232"), "TK", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(944), "Tokelau", null },
                    { new Guid("00000000-0000-0000-0000-000000000233"), "TL", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(945), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(946), "Timor-Leste", null },
                    { new Guid("00000000-0000-0000-0000-000000000234"), "TM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(947), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(947), "Turkmenistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000235"), "TN", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(949), "Tunisia", null },
                    { new Guid("00000000-0000-0000-0000-000000000236"), "TO", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(950), "Tonga", null },
                    { new Guid("00000000-0000-0000-0000-000000000237"), "TV", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(952), "Tuvalu", null },
                    { new Guid("00000000-0000-0000-0000-000000000238"), "TW", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(959), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(959), "Taiwan", null },
                    { new Guid("00000000-0000-0000-0000-000000000239"), "TZ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(962), "Tanzania", null },
                    { new Guid("00000000-0000-0000-0000-000000000240"), "UG", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(963), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(964), "Uganda", null },
                    { new Guid("00000000-0000-0000-0000-000000000241"), "UM", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(965), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(965), "United States Minor Outlying Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000242"), "UZ", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(967), "Uzbekistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000243"), "VA", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(968), "Vatican City", null },
                    { new Guid("00000000-0000-0000-0000-000000000244"), "VC", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(970), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(971), "Saint Vincent and the Grenadines", null },
                    { new Guid("00000000-0000-0000-0000-000000000245"), "VG", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(972), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(972), "British Virgin Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000246"), "VU", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(973), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(974), "Vanuatu", null },
                    { new Guid("00000000-0000-0000-0000-000000000247"), "WF", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(976), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(976), "Wallis and Futuna", null },
                    { new Guid("00000000-0000-0000-0000-000000000248"), "WS", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(978), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(978), "Samoa", null },
                    { new Guid("00000000-0000-0000-0000-000000000249"), "YT", new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(979), "Mayotte", null }
                });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 458, DateTimeKind.Utc).AddTicks(3997), new DateTime(2026, 7, 8, 11, 10, 41, 458, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "85f04a8d-53d9-48bb-9948-4e2c3c35fa74");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "399c67c6-a4da-4493-942c-509e2c83b05d");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 474, DateTimeKind.Utc).AddTicks(7051), new DateTime(2026, 7, 8, 11, 10, 41, 474, DateTimeKind.Utc).AddTicks(7054) });

            migrationBuilder.InsertData(
                table: "saleschannel_sync_state",
                columns: new[] { "Id", "CustomerImportPageCursor", "DateCreated", "DateModified", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "LastSyncStartedAt", "SalesChannelId", "SalesImportBackfillCursor", "TenantId" },
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), 0, new DateTime(2026, 7, 8, 11, 10, 41, 477, DateTimeKind.Utc).AddTicks(9604), new DateTime(2026, 7, 8, 11, 10, 41, 477, DateTimeKind.Utc).AddTicks(9607), false, false, false, false, null, new Guid("88888888-8888-8888-8888-888888888888"), null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 516, DateTimeKind.Utc).AddTicks(9422), new DateTime(2026, 7, 8, 11, 10, 41, 516, DateTimeKind.Utc).AddTicks(9423) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(322), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(326), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(326) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(328), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(608), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(609) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(614), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(614) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(619), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(619) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(621), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(332), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(334), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(344), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(346), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(598), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(601), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(601) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(603), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(603) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(605), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(606), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(607) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(615), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(617), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(617) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3529), new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3748), new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3750), new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_sync_state_SalesChannelId",
                table: "saleschannel_sync_state",
                column: "SalesChannelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_sync_state_TenantId",
                table: "saleschannel_sync_state",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saleschannel_sync_state");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"));

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "Bic",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "VatId",
                table: "tenant");

            migrationBuilder.AddColumn<int>(
                name: "CustomerImportPageCursor",
                table: "saleschannel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialProductExportCompleted",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialProductImportCompleted",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialSalesImportCompleted",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSyncStartedAt",
                table: "saleschannel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesImportBackfillCursor",
                table: "saleschannel",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "CustomerImportPageCursor", "DateCreated", "DateModified", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "LastSyncStartedAt", "SalesImportBackfillCursor" },
                values: new object[] { 0, new DateTime(2026, 7, 7, 16, 53, 2, 421, DateTimeKind.Utc).AddTicks(3878), new DateTime(2026, 7, 7, 16, 53, 2, 421, DateTimeKind.Utc).AddTicks(3881), false, false, false, false, null, null });

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
        }
    }
}
