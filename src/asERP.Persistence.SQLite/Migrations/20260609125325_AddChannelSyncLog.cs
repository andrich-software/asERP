using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddChannelSyncLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LockoutEnd",
                table: "user",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DateEnrollment",
                table: "customer",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "channel_sync_log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Operation = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    Exception = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel_sync_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_channel_sync_log_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    TokenHash = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Family = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReplacedByTokenId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsPersistent = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2530), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "192c8994-76a1-4d7e-acb6-27844d9d22da");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "feb3269f-d5bf-47d4-823b-cdc866dbfc75");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 430, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 6, 9, 12, 53, 25, 430, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5250), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5420), new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5420) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520), new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520), new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 417, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 417, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "LockoutEnd", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d5830a9-93ec-468d-84ea-4d6f7e3341ea", new DateTime(2026, 6, 9, 12, 53, 25, 383, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 6, 9, 12, 53, 25, 383, DateTimeKind.Utc).AddTicks(3730), null, "AQAAAAIAAYagAAAAENpzcjuOlhNJ/eTRpylfocV8FbRIMuPgXO/0E1JpZifySnNSQ2RQXh2yVYi7Ot1R/w==", "4a534ec2-8d94-47a3-acbf-fa16de40d9a0" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 420, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 6, 9, 12, 53, 25, 420, DateTimeKind.Utc).AddTicks(780), new Guid("c1d9af72-62ff-48c3-898e-d98458613357") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_log_CorrelationId",
                table: "channel_sync_log",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_log_SalesChannelId_Timestamp",
                table: "channel_sync_log",
                columns: new[] { "SalesChannelId", "Timestamp" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_log_Timestamp",
                table: "channel_sync_log",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_ExpiresAt",
                table: "refresh_token",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_Family",
                table: "refresh_token",
                column: "Family");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_TokenHash",
                table: "refresh_token",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "channel_sync_log");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "user",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateEnrollment",
                table: "customer",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2190), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2580), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2580), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2590), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2590), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2590), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2610), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2610), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2610), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2620), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2620), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2620), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2640), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2640), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2640), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2650), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2650), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2650), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2690), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2690), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2690), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2740), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2740), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2740), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2760), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2760), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2760), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2810), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2810), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2810), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2890), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2890), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2890), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2900), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "8c9bc36b-b135-4d47-862a-b050363d47b1");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6238d92f-e293-4d7f-92a3-b33c3df09d77");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 85, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 5, 2, 20, 7, 38, 85, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9480), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9480), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 5, 2, 20, 7, 38, 92, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 86, DateTimeKind.Utc).AddTicks(2530), new DateTime(2026, 5, 2, 20, 7, 38, 86, DateTimeKind.Utc).AddTicks(2530) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 86, DateTimeKind.Utc).AddTicks(2640), new DateTime(2026, 5, 2, 20, 7, 38, 86, DateTimeKind.Utc).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 86, DateTimeKind.Utc).AddTicks(2640), new DateTime(2026, 5, 2, 20, 7, 38, 86, DateTimeKind.Utc).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 71, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 5, 2, 20, 7, 38, 71, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "LockoutEnd", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d36bf3d-36db-4e1c-84b4-a6a3a9b14c22", new DateTime(2026, 5, 2, 20, 7, 38, 36, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 5, 2, 20, 7, 38, 36, DateTimeKind.Utc).AddTicks(4280), null, "AQAAAAIAAYagAAAAEOqcf/HYGDv1tbvaHfevnO/AOHHui4ulquZuVeyeaAlEy4xGuY5zHEChf0X6TzvG4w==", "85494942-610b-4569-9149-6471c0d3b07a" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 73, DateTimeKind.Utc).AddTicks(8600), new DateTime(2026, 5, 2, 20, 7, 38, 73, DateTimeKind.Utc).AddTicks(8700), new Guid("af283b58-91c4-49e1-9c10-865a3585ea13") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(4440), new DateTime(2026, 5, 2, 20, 7, 38, 76, DateTimeKind.Utc).AddTicks(4440) });
        }
    }
}
