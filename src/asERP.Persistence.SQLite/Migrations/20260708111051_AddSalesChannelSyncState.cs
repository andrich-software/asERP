using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asERP.Persistence.SQLite.Migrations
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
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bic",
                table: "tenant",
                type: "TEXT",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "tenant",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "tenant",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VatId",
                table: "tenant",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "saleschannel_sync_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InitialProductImportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialProductExportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialCustomerImportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialSalesImportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SalesImportBackfillCursor = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CustomerImportPageCursor = table.Column<int>(type: "INTEGER", nullable: false),
                    LastSyncStartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
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
            // Must run before the DropColumns below (on SQLite a column drop rebuilds the table). The demo
            // POS channel is seeded separately below and excluded here to avoid a duplicate row.
            migrationBuilder.Sql(@"
                INSERT INTO saleschannel_sync_state
                    (""Id"", ""SalesChannelId"", ""InitialProductImportCompleted"", ""InitialProductExportCompleted"",
                     ""InitialCustomerImportCompleted"", ""InitialSalesImportCompleted"", ""SalesImportBackfillCursor"",
                     ""CustomerImportPageCursor"", ""LastSyncStartedAt"", ""DateCreated"", ""DateModified"", ""TenantId"")
                SELECT lower(hex(randomblob(4)) || '-' || hex(randomblob(2)) || '-4' || substr(hex(randomblob(2)), 2) || '-' ||
                             substr('89ab', abs(random()) % 4 + 1, 1) || substr(hex(randomblob(2)), 2) || '-' || hex(randomblob(6))),
                       sc.""Id"", sc.""InitialProductImportCompleted"", sc.""InitialProductExportCompleted"",
                       sc.""InitialCustomerImportCompleted"", sc.""InitialSalesImportCompleted"", sc.""SalesImportBackfillCursor"",
                       sc.""CustomerImportPageCursor"", sc.""LastSyncStartedAt"",
                       strftime('%Y-%m-%d %H:%M:%S', 'now'), strftime('%Y-%m-%d %H:%M:%S', 'now'), sc.""TenantId""
                FROM saleschannel sc
                WHERE sc.""Id"" <> '88888888-8888-8888-8888-888888888888'
                  AND NOT EXISTS (SELECT 1 FROM saleschannel_sync_state ss WHERE ss.""SalesChannelId"" = sc.""Id"");
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
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(4912), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(4916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5721), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5724), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5732), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5734), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5736), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5738), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5739), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5741), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5741) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5742), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5744), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5747), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5749), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5768), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5770), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5783), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5783) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5785), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5791), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5792), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5794), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5796), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5797), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5809), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5811), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5820), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5824), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5838), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5841), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5846), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5848), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5850), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5851), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5853), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5856), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5857), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5859), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5860), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5873), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5875), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5878), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5879), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5881), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5884), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5887), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5889), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5892), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5893), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5895), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5897), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5905), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5910), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5913), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5914), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5916), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5918), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5919), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5921), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5925), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5928), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5930), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5931), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5933), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5941), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5944), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5945), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5950), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5951), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5954), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5956), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5958), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5959), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5961), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5964), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5965), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5967), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5973), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5983), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5984), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5987), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5991), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5993), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5995), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5996), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5998), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5999), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6001), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6004), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6005), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6007), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6008), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6016), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6018), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6020), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6022), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6026), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6028), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6029), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6031), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "CountryCode", "DateCreated", "DateModified", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000121"), "AE", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6032), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6033), "United Arab Emirates", null },
                    { new Guid("00000000-0000-0000-0000-000000000122"), "AI", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6034), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6034), "Anguilla", null },
                    { new Guid("00000000-0000-0000-0000-000000000123"), "AS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6037), "American Samoa", null },
                    { new Guid("00000000-0000-0000-0000-000000000124"), "AW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6040), "Aruba", null },
                    { new Guid("00000000-0000-0000-0000-000000000125"), "BD", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6041), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6041), "Bangladesh", null },
                    { new Guid("00000000-0000-0000-0000-000000000126"), "BF", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6043), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6043), "Burkina Faso", null },
                    { new Guid("00000000-0000-0000-0000-000000000127"), "BH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6044), "Bahrain", null },
                    { new Guid("00000000-0000-0000-0000-000000000128"), "BI", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6053), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6053), "Burundi", null },
                    { new Guid("00000000-0000-0000-0000-000000000129"), "BJ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6055), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6055), "Benin", null },
                    { new Guid("00000000-0000-0000-0000-000000000130"), "BM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6056), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6056), "Bermuda", null },
                    { new Guid("00000000-0000-0000-0000-000000000131"), "BN", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6058), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6058), "Brunei", null },
                    { new Guid("00000000-0000-0000-0000-000000000132"), "BQ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6061), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6061), "Bonaire, Sint Eustatius and Saba", null },
                    { new Guid("00000000-0000-0000-0000-000000000133"), "BT", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6062), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6063), "Bhutan", null },
                    { new Guid("00000000-0000-0000-0000-000000000134"), "BV", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6064), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6064), "Bouvet Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000135"), "BW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6066), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6066), "Botswana", null },
                    { new Guid("00000000-0000-0000-0000-000000000136"), "CD", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6067), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6067), "Democratic Republic of the Congo", null },
                    { new Guid("00000000-0000-0000-0000-000000000137"), "CF", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6069), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6069), "Central African Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000138"), "CG", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6071), "Republic of the Congo", null },
                    { new Guid("00000000-0000-0000-0000-000000000139"), "CK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6072), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6072), "Cook Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000140"), "CM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6075), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6075), "Cameroon", null },
                    { new Guid("00000000-0000-0000-0000-000000000141"), "CV", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6076), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6076), "Cape Verde", null },
                    { new Guid("00000000-0000-0000-0000-000000000142"), "CW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6078), "Curaçao", null },
                    { new Guid("00000000-0000-0000-0000-000000000143"), "CX", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6079), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6080), "Christmas Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000144"), "DJ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6088), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6088), "Djibouti", null },
                    { new Guid("00000000-0000-0000-0000-000000000145"), "DM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6090), "Dominica", null },
                    { new Guid("00000000-0000-0000-0000-000000000146"), "EH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6092), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6092), "Western Sahara", null },
                    { new Guid("00000000-0000-0000-0000-000000000147"), "FJ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6094), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6094), "Fiji", null },
                    { new Guid("00000000-0000-0000-0000-000000000148"), "FK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6097), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6097), "Falkland Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000149"), "FM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6098), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6098), "Micronesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000150"), "FO", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6100), "Faroe Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000151"), "GA", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6101), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6102), "Gabon", null },
                    { new Guid("00000000-0000-0000-0000-000000000152"), "GD", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6103), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6103), "Grenada", null },
                    { new Guid("00000000-0000-0000-0000-000000000153"), "GG", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6105), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6105), "Guernsey", null },
                    { new Guid("00000000-0000-0000-0000-000000000154"), "GI", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6106), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6106), "Gibraltar", null },
                    { new Guid("00000000-0000-0000-0000-000000000155"), "GM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6108), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6108), "Gambia", null },
                    { new Guid("00000000-0000-0000-0000-000000000156"), "GN", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6110), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6111), "Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000157"), "GQ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6112), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6112), "Equatorial Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000158"), "GS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6114), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6114), "South Georgia and the South Sandwich Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000159"), "GU", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6115), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6115), "Guam", null },
                    { new Guid("00000000-0000-0000-0000-000000000160"), "GW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6123), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6123), "Guinea-Bissau", null },
                    { new Guid("00000000-0000-0000-0000-000000000161"), "HK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6125), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6126), "Hong Kong", null },
                    { new Guid("00000000-0000-0000-0000-000000000162"), "HM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6127), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6128), "Heard Island and McDonald Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000163"), "IL", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6129), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6129), "Israel", null },
                    { new Guid("00000000-0000-0000-0000-000000000164"), "IM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6132), "Isle of Man", null },
                    { new Guid("00000000-0000-0000-0000-000000000165"), "IO", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6134), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6134), "British Indian Ocean Territory", null },
                    { new Guid("00000000-0000-0000-0000-000000000166"), "IQ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6135), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6135), "Iraq", null },
                    { new Guid("00000000-0000-0000-0000-000000000167"), "JE", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6137), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6137), "Jersey", null },
                    { new Guid("00000000-0000-0000-0000-000000000168"), "JO", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6138), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6139), "Jordan", null },
                    { new Guid("00000000-0000-0000-0000-000000000169"), "KH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6141), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6141), "Cambodia", null },
                    { new Guid("00000000-0000-0000-0000-000000000170"), "KI", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6143), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6143), "Kiribati", null },
                    { new Guid("00000000-0000-0000-0000-000000000171"), "KM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6144), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6144), "Comoros", null },
                    { new Guid("00000000-0000-0000-0000-000000000172"), "KN", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6147), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6147), "Saint Kitts and Nevis", null },
                    { new Guid("00000000-0000-0000-0000-000000000173"), "KP", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6149), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6149), "North Korea", null },
                    { new Guid("00000000-0000-0000-0000-000000000174"), "KY", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6150), "Cayman Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000175"), "LA", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6152), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6152), "Laos", null },
                    { new Guid("00000000-0000-0000-0000-000000000176"), "LB", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6159), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6160), "Lebanon", null },
                    { new Guid("00000000-0000-0000-0000-000000000177"), "LC", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6161), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6161), "Saint Lucia", null },
                    { new Guid("00000000-0000-0000-0000-000000000178"), "LI", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6163), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6163), "Liechtenstein", null },
                    { new Guid("00000000-0000-0000-0000-000000000179"), "LK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6165), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6165), "Sri Lanka", null },
                    { new Guid("00000000-0000-0000-0000-000000000180"), "LR", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6167), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6168), "Liberia", null },
                    { new Guid("00000000-0000-0000-0000-000000000181"), "LS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6169), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6169), "Lesotho", null },
                    { new Guid("00000000-0000-0000-0000-000000000182"), "LY", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6171), "Libya", null },
                    { new Guid("00000000-0000-0000-0000-000000000183"), "ME", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6172), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6172), "Montenegro", null },
                    { new Guid("00000000-0000-0000-0000-000000000184"), "MH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6174), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6174), "Marshall Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000185"), "MK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6175), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6175), "North Macedonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000186"), "ML", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6177), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6177), "Mali", null },
                    { new Guid("00000000-0000-0000-0000-000000000187"), "MM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6178), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6178), "Myanmar", null },
                    { new Guid("00000000-0000-0000-0000-000000000188"), "MN", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6186), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6186), "Mongolia", null },
                    { new Guid("00000000-0000-0000-0000-000000000189"), "MO", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6188), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6188), "Macao", null },
                    { new Guid("00000000-0000-0000-0000-000000000190"), "MP", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6189), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6190), "Northern Mariana Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000191"), "MR", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6191), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6191), "Mauritania", null },
                    { new Guid("00000000-0000-0000-0000-000000000192"), "MS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6199), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6199), "Montserrat", null },
                    { new Guid("00000000-0000-0000-0000-000000000193"), "MU", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6202), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6202), "Mauritius", null },
                    { new Guid("00000000-0000-0000-0000-000000000194"), "MV", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6204), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6204), "Maldives", null },
                    { new Guid("00000000-0000-0000-0000-000000000195"), "MW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6205), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6205), "Malawi", null },
                    { new Guid("00000000-0000-0000-0000-000000000196"), "MZ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6208), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6208), "Mozambique", null },
                    { new Guid("00000000-0000-0000-0000-000000000197"), "NA", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6210), "Namibia", null },
                    { new Guid("00000000-0000-0000-0000-000000000198"), "NC", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6211), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6211), "New Caledonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000199"), "NE", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6213), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6213), "Niger", null },
                    { new Guid("00000000-0000-0000-0000-000000000200"), "NF", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6214), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6215), "Norfolk Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000201"), "NP", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6216), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6216), "Nepal", null },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "NR", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6218), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6218), "Nauru", null },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "NU", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6219), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6219), "Niue", null },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "PF", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6222), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6222), "French Polynesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000205"), "PG", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6223), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6223), "Papua New Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000206"), "PH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6225), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6225), "Philippines", null },
                    { new Guid("00000000-0000-0000-0000-000000000207"), "PK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6226), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6226), "Pakistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000208"), "PN", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6234), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6234), "Pitcairn Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000209"), "PS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6236), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6236), "Palestine", null },
                    { new Guid("00000000-0000-0000-0000-000000000210"), "PW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6238), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6238), "Palau", null },
                    { new Guid("00000000-0000-0000-0000-000000000211"), "RE", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6239), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6240), "Réunion", null },
                    { new Guid("00000000-0000-0000-0000-000000000212"), "RW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6242), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6242), "Rwanda", null },
                    { new Guid("00000000-0000-0000-0000-000000000213"), "SB", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6244), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6244), "Solomon Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000214"), "SC", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6246), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6246), "Seychelles", null },
                    { new Guid("00000000-0000-0000-0000-000000000215"), "SD", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6247), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6248), "Sudan", null },
                    { new Guid("00000000-0000-0000-0000-000000000216"), "SH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6249), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6249), "Saint Helena", null },
                    { new Guid("00000000-0000-0000-0000-000000000217"), "SJ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6252), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6252), "Svalbard and Jan Mayen", null },
                    { new Guid("00000000-0000-0000-0000-000000000218"), "SL", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6253), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6253), "Sierra Leone", null },
                    { new Guid("00000000-0000-0000-0000-000000000219"), "SM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6255), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6255), "San Marino", null },
                    { new Guid("00000000-0000-0000-0000-000000000220"), "SO", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6257), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6258), "Somalia", null },
                    { new Guid("00000000-0000-0000-0000-000000000221"), "SS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6259), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6259), "South Sudan", null },
                    { new Guid("00000000-0000-0000-0000-000000000222"), "ST", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6261), "São Tomé and Príncipe", null },
                    { new Guid("00000000-0000-0000-0000-000000000223"), "SX", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6262), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6262), "Sint Maarten", null },
                    { new Guid("00000000-0000-0000-0000-000000000224"), "SY", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6271), "Syria", null },
                    { new Guid("00000000-0000-0000-0000-000000000225"), "SZ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6273), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6273), "Eswatini", null },
                    { new Guid("00000000-0000-0000-0000-000000000226"), "TC", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6275), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6275), "Turks and Caicos Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000227"), "TD", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6276), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6276), "Chad", null },
                    { new Guid("00000000-0000-0000-0000-000000000228"), "TF", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6279), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6279), "French Southern Territories", null },
                    { new Guid("00000000-0000-0000-0000-000000000229"), "TG", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6281), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6281), "Togo", null },
                    { new Guid("00000000-0000-0000-0000-000000000230"), "TH", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6282), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6283), "Thailand", null },
                    { new Guid("00000000-0000-0000-0000-000000000231"), "TJ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6284), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6284), "Tajikistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000232"), "TK", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6286), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6286), "Tokelau", null },
                    { new Guid("00000000-0000-0000-0000-000000000233"), "TL", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6287), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6287), "Timor-Leste", null },
                    { new Guid("00000000-0000-0000-0000-000000000234"), "TM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6289), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6289), "Turkmenistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000235"), "TN", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6290), "Tunisia", null },
                    { new Guid("00000000-0000-0000-0000-000000000236"), "TO", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6293), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6293), "Tonga", null },
                    { new Guid("00000000-0000-0000-0000-000000000237"), "TV", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6295), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6295), "Tuvalu", null },
                    { new Guid("00000000-0000-0000-0000-000000000238"), "TW", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6296), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6296), "Taiwan", null },
                    { new Guid("00000000-0000-0000-0000-000000000239"), "TZ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6298), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6298), "Tanzania", null },
                    { new Guid("00000000-0000-0000-0000-000000000240"), "UG", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6306), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6307), "Uganda", null },
                    { new Guid("00000000-0000-0000-0000-000000000241"), "UM", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6308), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6308), "United States Minor Outlying Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000242"), "UZ", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6310), "Uzbekistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000243"), "VA", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6311), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6312), "Vatican City", null },
                    { new Guid("00000000-0000-0000-0000-000000000244"), "VC", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6314), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6314), "Saint Vincent and the Grenadines", null },
                    { new Guid("00000000-0000-0000-0000-000000000245"), "VG", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6316), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6316), "British Virgin Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000246"), "VU", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6317), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6318), "Vanuatu", null },
                    { new Guid("00000000-0000-0000-0000-000000000247"), "WF", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6319), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6319), "Wallis and Futuna", null },
                    { new Guid("00000000-0000-0000-0000-000000000248"), "WS", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6321), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6321), "Samoa", null },
                    { new Guid("00000000-0000-0000-0000-000000000249"), "YT", new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6322), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6322), "Mayotte", null }
                });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(9138), new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "3669273e-9fce-473e-a307-81c52657b4ed");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d68af6de-cb97-4b47-b1cc-873c26467ad2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 424, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 7, 8, 11, 10, 50, 424, DateTimeKind.Utc).AddTicks(1467) });

            migrationBuilder.InsertData(
                table: "saleschannel_sync_state",
                columns: new[] { "Id", "CustomerImportPageCursor", "DateCreated", "DateModified", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "LastSyncStartedAt", "SalesChannelId", "SalesImportBackfillCursor", "TenantId" },
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), 0, new DateTime(2026, 7, 8, 11, 10, 50, 429, DateTimeKind.Utc).AddTicks(4639), new DateTime(2026, 7, 8, 11, 10, 50, 429, DateTimeKind.Utc).AddTicks(4643), false, false, false, false, null, new Guid("88888888-8888-8888-8888-888888888888"), null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(5499), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(5505) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6037) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6039), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6039) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6189), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6189) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6197), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6197) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6198), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6198) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6042), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6044) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6045), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6045) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6180), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6182), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6184), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6184) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6185), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6187), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6187) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6194), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6194) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6195), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 431, DateTimeKind.Utc).AddTicks(9750), new DateTime(2026, 7, 8, 11, 10, 50, 431, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(142), new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(147), new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(147) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(1890), new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(1891) });

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
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialProductExportCompleted",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialProductImportCompleted",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialSalesImportCompleted",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSyncStartedAt",
                table: "saleschannel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesImportBackfillCursor",
                table: "saleschannel",
                type: "TEXT",
                nullable: true);

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
                columns: new[] { "CustomerImportPageCursor", "DateCreated", "DateModified", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "LastSyncStartedAt", "SalesImportBackfillCursor" },
                values: new object[] { 0, new DateTime(2026, 7, 7, 16, 52, 2, 949, DateTimeKind.Utc).AddTicks(9189), new DateTime(2026, 7, 7, 16, 52, 2, 949, DateTimeKind.Utc).AddTicks(9194), false, false, false, false, null, null });

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
        }
    }
}
