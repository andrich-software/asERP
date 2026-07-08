using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asERP.Persistence.PostgreSQL.Migrations
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
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bic",
                table: "tenant",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "tenant",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "tenant",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VatId",
                table: "tenant",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "saleschannel_sync_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitialProductImportCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    InitialProductExportCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    InitialCustomerImportCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    InitialSalesImportCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    SalesImportBackfillCursor = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerImportPageCursor = table.Column<int>(type: "integer", nullable: false),
                    LastSyncStartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    (""Id"", ""SalesChannelId"", ""InitialProductImportCompleted"", ""InitialProductExportCompleted"",
                     ""InitialCustomerImportCompleted"", ""InitialSalesImportCompleted"", ""SalesImportBackfillCursor"",
                     ""CustomerImportPageCursor"", ""LastSyncStartedAt"", ""DateCreated"", ""DateModified"", ""TenantId"")
                SELECT gen_random_uuid(), sc.""Id"", sc.""InitialProductImportCompleted"", sc.""InitialProductExportCompleted"",
                       sc.""InitialCustomerImportCompleted"", sc.""InitialSalesImportCompleted"", sc.""SalesImportBackfillCursor"",
                       sc.""CustomerImportPageCursor"", sc.""LastSyncStartedAt"", now(), now(), sc.""TenantId""
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
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5276), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5979), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5983), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5985), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5986), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5988), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5989), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5993), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5995), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5997), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5998), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6000), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6001), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6003), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6013), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6017), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6018), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6020), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6022), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6023), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6039), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6041), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6046), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6049), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6051), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6060), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6063), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6072), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6075), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6077), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6080), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6083), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6085), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6086), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6089), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6091), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6092), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6093), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6095), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6097), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6098), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6107), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6109), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6111), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6113), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6115), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6117), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6119), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6122), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6124), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6126), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6127), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6129), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6129) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6130), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6133), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6143), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6146), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6148), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6148) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6149), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6151), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6151) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6153), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6153) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6154), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6156), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6158), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6161), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6162), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6164), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6165), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6167), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6169), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6178), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6181), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6183), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6185), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6186), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6188), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6191), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6193), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6196), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6197), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6199), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6201), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6202), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6204), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6205), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6213), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6216), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6218), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6219), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6221), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6222), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6224), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6225), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6227), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6231), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6232), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6234), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6235), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6237), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6238), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6246), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6251), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6258), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6259), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6261), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6263), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6264), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6266), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6266) });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "CountryCode", "DateCreated", "DateModified", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000121"), "AE", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6269), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6269), "United Arab Emirates", null },
                    { new Guid("00000000-0000-0000-0000-000000000122"), "AI", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6271), "Anguilla", null },
                    { new Guid("00000000-0000-0000-0000-000000000123"), "AS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6272), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6272), "American Samoa", null },
                    { new Guid("00000000-0000-0000-0000-000000000124"), "AW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6273), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6274), "Aruba", null },
                    { new Guid("00000000-0000-0000-0000-000000000125"), "BD", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6275), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6275), "Bangladesh", null },
                    { new Guid("00000000-0000-0000-0000-000000000126"), "BF", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6277), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6277), "Burkina Faso", null },
                    { new Guid("00000000-0000-0000-0000-000000000127"), "BH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6278), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6278), "Bahrain", null },
                    { new Guid("00000000-0000-0000-0000-000000000128"), "BI", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6287), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6287), "Burundi", null },
                    { new Guid("00000000-0000-0000-0000-000000000129"), "BJ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6290), "Benin", null },
                    { new Guid("00000000-0000-0000-0000-000000000130"), "BM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6292), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6292), "Bermuda", null },
                    { new Guid("00000000-0000-0000-0000-000000000131"), "BN", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6293), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6293), "Brunei", null },
                    { new Guid("00000000-0000-0000-0000-000000000132"), "BQ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6295), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6295), "Bonaire, Sint Eustatius and Saba", null },
                    { new Guid("00000000-0000-0000-0000-000000000133"), "BT", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6297), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6297), "Bhutan", null },
                    { new Guid("00000000-0000-0000-0000-000000000134"), "BV", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6298), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6298), "Bouvet Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000135"), "BW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6300), "Botswana", null },
                    { new Guid("00000000-0000-0000-0000-000000000136"), "CD", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6301), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6302), "Democratic Republic of the Congo", null },
                    { new Guid("00000000-0000-0000-0000-000000000137"), "CF", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6304), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6304), "Central African Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000138"), "CG", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6306), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6306), "Republic of the Congo", null },
                    { new Guid("00000000-0000-0000-0000-000000000139"), "CK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6307), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6307), "Cook Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000140"), "CM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6309), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6309), "Cameroon", null },
                    { new Guid("00000000-0000-0000-0000-000000000141"), "CV", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6311), "Cape Verde", null },
                    { new Guid("00000000-0000-0000-0000-000000000142"), "CW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6312), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6312), "Curaçao", null },
                    { new Guid("00000000-0000-0000-0000-000000000143"), "CX", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6314), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6314), "Christmas Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000144"), "DJ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6322), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6323), "Djibouti", null },
                    { new Guid("00000000-0000-0000-0000-000000000145"), "DM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6325), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6325), "Dominica", null },
                    { new Guid("00000000-0000-0000-0000-000000000146"), "EH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6327), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6327), "Western Sahara", null },
                    { new Guid("00000000-0000-0000-0000-000000000147"), "FJ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6328), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6329), "Fiji", null },
                    { new Guid("00000000-0000-0000-0000-000000000148"), "FK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6330), "Falkland Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000149"), "FM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6332), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6332), "Micronesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000150"), "FO", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6334), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6334), "Faroe Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000151"), "GA", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6335), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6335), "Gabon", null },
                    { new Guid("00000000-0000-0000-0000-000000000152"), "GD", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6337), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6337), "Grenada", null },
                    { new Guid("00000000-0000-0000-0000-000000000153"), "GG", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6340), "Guernsey", null },
                    { new Guid("00000000-0000-0000-0000-000000000154"), "GI", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6341), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6341), "Gibraltar", null },
                    { new Guid("00000000-0000-0000-0000-000000000155"), "GM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6343), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6343), "Gambia", null },
                    { new Guid("00000000-0000-0000-0000-000000000156"), "GN", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6344), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6345), "Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000157"), "GQ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6346), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6346), "Equatorial Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000158"), "GS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6347), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6348), "South Georgia and the South Sandwich Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000159"), "GU", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6349), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6349), "Guam", null },
                    { new Guid("00000000-0000-0000-0000-000000000160"), "GW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6357), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6357), "Guinea-Bissau", null },
                    { new Guid("00000000-0000-0000-0000-000000000161"), "HK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6360), "Hong Kong", null },
                    { new Guid("00000000-0000-0000-0000-000000000162"), "HM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6361), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6362), "Heard Island and McDonald Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000163"), "IL", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6363), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6363), "Israel", null },
                    { new Guid("00000000-0000-0000-0000-000000000164"), "IM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6365), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6365), "Isle of Man", null },
                    { new Guid("00000000-0000-0000-0000-000000000165"), "IO", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6366), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6366), "British Indian Ocean Territory", null },
                    { new Guid("00000000-0000-0000-0000-000000000166"), "IQ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6368), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6368), "Iraq", null },
                    { new Guid("00000000-0000-0000-0000-000000000167"), "JE", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6369), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6370), "Jersey", null },
                    { new Guid("00000000-0000-0000-0000-000000000168"), "JO", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6371), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6371), "Jordan", null },
                    { new Guid("00000000-0000-0000-0000-000000000169"), "KH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6374), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6374), "Cambodia", null },
                    { new Guid("00000000-0000-0000-0000-000000000170"), "KI", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6375), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6375), "Kiribati", null },
                    { new Guid("00000000-0000-0000-0000-000000000171"), "KM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6377), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6377), "Comoros", null },
                    { new Guid("00000000-0000-0000-0000-000000000172"), "KN", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6379), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6379), "Saint Kitts and Nevis", null },
                    { new Guid("00000000-0000-0000-0000-000000000173"), "KP", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6380), "North Korea", null },
                    { new Guid("00000000-0000-0000-0000-000000000174"), "KY", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6382), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6382), "Cayman Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000175"), "LA", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6383), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6384), "Laos", null },
                    { new Guid("00000000-0000-0000-0000-000000000176"), "LB", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6385), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6385), "Lebanon", null },
                    { new Guid("00000000-0000-0000-0000-000000000177"), "LC", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6394), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6394), "Saint Lucia", null },
                    { new Guid("00000000-0000-0000-0000-000000000178"), "LI", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6396), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6396), "Liechtenstein", null },
                    { new Guid("00000000-0000-0000-0000-000000000179"), "LK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6397), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6398), "Sri Lanka", null },
                    { new Guid("00000000-0000-0000-0000-000000000180"), "LR", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6399), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6399), "Liberia", null },
                    { new Guid("00000000-0000-0000-0000-000000000181"), "LS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6401), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6401), "Lesotho", null },
                    { new Guid("00000000-0000-0000-0000-000000000182"), "LY", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6402), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6403), "Libya", null },
                    { new Guid("00000000-0000-0000-0000-000000000183"), "ME", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6404), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6404), "Montenegro", null },
                    { new Guid("00000000-0000-0000-0000-000000000184"), "MH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6406), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6406), "Marshall Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000185"), "MK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6409), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6409), "North Macedonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000186"), "ML", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6411), "Mali", null },
                    { new Guid("00000000-0000-0000-0000-000000000187"), "MM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6412), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6412), "Myanmar", null },
                    { new Guid("00000000-0000-0000-0000-000000000188"), "MN", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6414), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6414), "Mongolia", null },
                    { new Guid("00000000-0000-0000-0000-000000000189"), "MO", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6415), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6415), "Macao", null },
                    { new Guid("00000000-0000-0000-0000-000000000190"), "MP", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6417), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6417), "Northern Mariana Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000191"), "MR", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6418), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6419), "Mauritania", null },
                    { new Guid("00000000-0000-0000-0000-000000000192"), "MS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6420), "Montserrat", null },
                    { new Guid("00000000-0000-0000-0000-000000000193"), "MU", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6429), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6430), "Mauritius", null },
                    { new Guid("00000000-0000-0000-0000-000000000194"), "MV", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6432), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6432), "Maldives", null },
                    { new Guid("00000000-0000-0000-0000-000000000195"), "MW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6434), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6434), "Malawi", null },
                    { new Guid("00000000-0000-0000-0000-000000000196"), "MZ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6435), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6435), "Mozambique", null },
                    { new Guid("00000000-0000-0000-0000-000000000197"), "NA", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6437), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6437), "Namibia", null },
                    { new Guid("00000000-0000-0000-0000-000000000198"), "NC", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6438), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6439), "New Caledonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000199"), "NE", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6440), "Niger", null },
                    { new Guid("00000000-0000-0000-0000-000000000200"), "NF", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6441), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6442), "Norfolk Island", null },
                    { new Guid("00000000-0000-0000-0000-000000000201"), "NP", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6444), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6444), "Nepal", null },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "NR", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6446), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6446), "Nauru", null },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "NU", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6447), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6447), "Niue", null },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "PF", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6449), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6449), "French Polynesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000205"), "PG", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6451), "Papua New Guinea", null },
                    { new Guid("00000000-0000-0000-0000-000000000206"), "PH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6452), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6452), "Philippines", null },
                    { new Guid("00000000-0000-0000-0000-000000000207"), "PK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6453), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6454), "Pakistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000208"), "PN", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6459), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6459), "Pitcairn Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000209"), "PS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6468), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6468), "Palestine", null },
                    { new Guid("00000000-0000-0000-0000-000000000210"), "PW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6470), "Palau", null },
                    { new Guid("00000000-0000-0000-0000-000000000211"), "RE", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6471), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6472), "Réunion", null },
                    { new Guid("00000000-0000-0000-0000-000000000212"), "RW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6473), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6473), "Rwanda", null },
                    { new Guid("00000000-0000-0000-0000-000000000213"), "SB", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6475), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6475), "Solomon Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000214"), "SC", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6476), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6477), "Seychelles", null },
                    { new Guid("00000000-0000-0000-0000-000000000215"), "SD", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6478), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6478), "Sudan", null },
                    { new Guid("00000000-0000-0000-0000-000000000216"), "SH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6480), "Saint Helena", null },
                    { new Guid("00000000-0000-0000-0000-000000000217"), "SJ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6482), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6482), "Svalbard and Jan Mayen", null },
                    { new Guid("00000000-0000-0000-0000-000000000218"), "SL", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6484), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6484), "Sierra Leone", null },
                    { new Guid("00000000-0000-0000-0000-000000000219"), "SM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6485), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6486), "San Marino", null },
                    { new Guid("00000000-0000-0000-0000-000000000220"), "SO", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6487), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6487), "Somalia", null },
                    { new Guid("00000000-0000-0000-0000-000000000221"), "SS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6488), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6489), "South Sudan", null },
                    { new Guid("00000000-0000-0000-0000-000000000222"), "ST", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6490), "São Tomé and Príncipe", null },
                    { new Guid("00000000-0000-0000-0000-000000000223"), "SX", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6491), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6492), "Sint Maarten", null },
                    { new Guid("00000000-0000-0000-0000-000000000224"), "SY", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6493), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6493), "Syria", null },
                    { new Guid("00000000-0000-0000-0000-000000000225"), "SZ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6502), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6502), "Eswatini", null },
                    { new Guid("00000000-0000-0000-0000-000000000226"), "TC", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6504), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6504), "Turks and Caicos Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000227"), "TD", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6505), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6506), "Chad", null },
                    { new Guid("00000000-0000-0000-0000-000000000228"), "TF", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6507), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6507), "French Southern Territories", null },
                    { new Guid("00000000-0000-0000-0000-000000000229"), "TG", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6508), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6509), "Togo", null },
                    { new Guid("00000000-0000-0000-0000-000000000230"), "TH", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6511), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6511), "Thailand", null },
                    { new Guid("00000000-0000-0000-0000-000000000231"), "TJ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6512), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6512), "Tajikistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000232"), "TK", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6514), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6514), "Tokelau", null },
                    { new Guid("00000000-0000-0000-0000-000000000233"), "TL", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6516), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6517), "Timor-Leste", null },
                    { new Guid("00000000-0000-0000-0000-000000000234"), "TM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6518), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6518), "Turkmenistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000235"), "TN", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6520), "Tunisia", null },
                    { new Guid("00000000-0000-0000-0000-000000000236"), "TO", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6521), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6521), "Tonga", null },
                    { new Guid("00000000-0000-0000-0000-000000000237"), "TV", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6523), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6523), "Tuvalu", null },
                    { new Guid("00000000-0000-0000-0000-000000000238"), "TW", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6525), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6525), "Taiwan", null },
                    { new Guid("00000000-0000-0000-0000-000000000239"), "TZ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6526), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6526), "Tanzania", null },
                    { new Guid("00000000-0000-0000-0000-000000000240"), "UG", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6528), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6528), "Uganda", null },
                    { new Guid("00000000-0000-0000-0000-000000000241"), "UM", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6531), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6531), "United States Minor Outlying Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000242"), "UZ", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6532), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6532), "Uzbekistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000243"), "VA", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6534), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6534), "Vatican City", null },
                    { new Guid("00000000-0000-0000-0000-000000000244"), "VC", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6535), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6536), "Saint Vincent and the Grenadines", null },
                    { new Guid("00000000-0000-0000-0000-000000000245"), "VG", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6537), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6537), "British Virgin Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000246"), "VU", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6539), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6539), "Vanuatu", null },
                    { new Guid("00000000-0000-0000-0000-000000000247"), "WF", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6540), "Wallis and Futuna", null },
                    { new Guid("00000000-0000-0000-0000-000000000248"), "WS", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6542), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6542), "Samoa", null },
                    { new Guid("00000000-0000-0000-0000-000000000249"), "YT", new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6544), new DateTime(2026, 7, 8, 11, 10, 26, 821, DateTimeKind.Utc).AddTicks(6545), "Mayotte", null }
                });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 822, DateTimeKind.Utc).AddTicks(8160), new DateTime(2026, 7, 8, 11, 10, 26, 822, DateTimeKind.Utc).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "d5fbde34-e9d0-472a-b5ce-80108db58b65");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "73e44c18-6535-4e3c-841d-da8194e1ed10");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 835, DateTimeKind.Utc).AddTicks(9295), new DateTime(2026, 7, 8, 11, 10, 26, 835, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.InsertData(
                table: "saleschannel_sync_state",
                columns: new[] { "Id", "CustomerImportPageCursor", "DateCreated", "DateModified", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "LastSyncStartedAt", "SalesChannelId", "SalesImportBackfillCursor", "TenantId" },
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), 0, new DateTime(2026, 7, 8, 11, 10, 26, 838, DateTimeKind.Utc).AddTicks(2603), new DateTime(2026, 7, 8, 11, 10, 26, 838, DateTimeKind.Utc).AddTicks(2604), false, false, false, false, null, new Guid("88888888-8888-8888-8888-888888888888"), null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(8722), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(8725) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9242), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9244), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9247), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9249), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9249) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9397), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9401) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9405), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9405) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9406), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9406) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9251) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9252), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9259), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9261), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9389), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9391), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9391) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9392), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9393) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9394), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9394) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9396), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9402), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9402) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9403), new DateTime(2026, 7, 8, 11, 10, 26, 866, DateTimeKind.Utc).AddTicks(9404) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 839, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 8, 11, 10, 26, 839, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 839, DateTimeKind.Utc).AddTicks(6619), new DateTime(2026, 7, 8, 11, 10, 26, 839, DateTimeKind.Utc).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 839, DateTimeKind.Utc).AddTicks(6621), new DateTime(2026, 7, 8, 11, 10, 26, 839, DateTimeKind.Utc).AddTicks(6622) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 8, 11, 10, 26, 822, DateTimeKind.Utc).AddTicks(1241), new DateTime(2026, 7, 8, 11, 10, 26, 822, DateTimeKind.Utc).AddTicks(1244) });

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
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialProductExportCompleted",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialProductImportCompleted",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InitialSalesImportCompleted",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSyncStartedAt",
                table: "saleschannel",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesImportBackfillCursor",
                table: "saleschannel",
                type: "timestamp with time zone",
                nullable: true);

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
                columns: new[] { "CustomerImportPageCursor", "DateCreated", "DateModified", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "LastSyncStartedAt", "SalesImportBackfillCursor" },
                values: new object[] { 0, new DateTime(2026, 7, 7, 16, 53, 16, 853, DateTimeKind.Utc).AddTicks(5101), new DateTime(2026, 7, 7, 16, 53, 16, 853, DateTimeKind.Utc).AddTicks(5104), false, false, false, false, null, null });

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
        }
    }
}
