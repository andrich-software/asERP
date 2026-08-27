using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations;

/// <inheritdoc />
public partial class AddSalesChannelOperationState : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_product_saleschannel_SalesChannelId",
            table: "product_saleschannel");

        migrationBuilder.AddColumn<DateTime>(
            name: "HeartbeatAt",
            table: "channel_sync_run",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "saleschannel_operation_state",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                Operation = table.Column<int>(type: "integer", nullable: false),
                Phase = table.Column<int>(type: "integer", nullable: false),
                NextDueAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CurrentIntervalSeconds = table.Column<int>(type: "integer", nullable: false),
                ConsecutiveFailures = table.Column<int>(type: "integer", nullable: false),
                Watermark = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                CursorDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                CursorPage = table.Column<int>(type: "integer", nullable: false),
                CursorText = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                LastStartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastSuccessAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastFullSweepAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_saleschannel_operation_state", x => x.Id);
                table.ForeignKey(
                    name: "FK_saleschannel_operation_state_saleschannel_SalesChannelId",
                    column: x => x.SalesChannelId,
                    principalTable: "saleschannel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(557), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(577) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1389), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1391), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1397) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1412), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1413) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1414), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1414) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1416), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1416) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1417), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1417) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1419), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1421) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1429), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1429) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1432), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1432) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1433), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1434) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1435), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1435) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1449), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1449) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1451) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1452), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1454), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1454) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1457), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1457) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1461), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1463) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1464), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1466), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1466) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1467), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1468) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1469), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1469) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1471) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1473), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1474) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1494), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1494) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1501), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1501) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1503), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1503) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1514), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1514) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1515), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1517), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1517) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1519), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1519) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1521), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1522) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1523), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1525), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1525) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1526), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1526) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1528), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1528) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1529), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1529) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1531), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1531) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1532), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1532) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1535), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1535) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1540) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1542), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1542) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1544), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1544) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1586) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1588), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1588) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1590), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1590) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1592) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1594), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1596), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1596) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1597), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1597) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1599) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1600), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1600) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1602), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1602) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1603), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1603) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1605), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1605) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1607), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1608) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1609) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1610), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1610) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1612), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1612) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1620), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1620) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1623), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1625), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1625) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1628), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1628) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1629), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1629) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1631), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1631) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1632), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1633) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1634), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1634) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1635), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1636) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1637), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1637) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1638), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1639) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1641), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1641) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1642), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1644), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1644) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1645), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1646) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1653) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1655), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1655) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1657) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1658), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1658) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1661), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1661) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1662), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1663) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1664), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1664) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1665), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1666) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1667), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1667) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1668), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1669) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1670), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1670) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1671), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1672) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1674), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1674) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1676) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1678), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1679) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1680), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1680) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1688), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1688) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1690), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1690) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1691), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1691) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1693), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1693) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1696) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1697) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1700) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1703), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1703) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1705), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1705) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1706), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1706) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1709), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1709) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1710), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1711) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1712), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1712) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1713), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1714) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1721), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1723), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1723) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1725), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1725) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1726), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1726) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1729), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1731) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1732), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1732) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1733), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1734) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1735), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1735) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1736), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1737) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1739), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1740) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1742), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1742) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1744), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1744) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1745), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1745) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1747), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1747) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1755), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1755) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1757), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1757) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1758), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1759) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1760) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1764), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1764) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1766), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1767), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1767) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1769), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1770) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1772), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1772) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1773), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1776), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1776) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1784), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1784) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1785), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1786) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1787), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1788) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1795), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1798) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1799), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1799) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1801), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1805) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1806), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1808), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1808) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1809), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1810) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1811) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1812), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1814) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1817), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1817) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1818), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1819) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1820), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1821), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1829), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1831), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1831) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1833) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1834), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1835) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1838), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1838) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1840), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1840) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1841), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1841) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1843), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1844), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1844) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1846), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1847), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1847) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1849), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1849) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1853), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1855), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1855) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1856), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1864) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1866), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1866) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1867), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1868) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1869), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1872), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1873), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1875), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1876), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1876) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1878), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1878) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1879), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1880) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1881), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1881) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1883) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1886), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1887) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1888), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1889), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1899), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1900) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1903), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1904), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1907), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1907) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1909), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1909) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1910), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1910) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1912), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1912) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1913), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1915), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1916), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1918), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1918) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1922), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1922) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1924) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1925), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1933), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1933) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1935), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1936), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1937) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1938), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1938) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1942), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1942) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1945), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1947), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1947) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1948), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1950), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1953), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1957), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1957) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1959) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1960), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1960) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1970), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1970) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1972), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1972) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1973), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1974) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1976), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1976) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1978), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1980) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1981), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1982), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1983) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1984), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1984) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1991) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1992), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1995), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1995) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1996), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1998), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1999), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1999) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2002), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2004), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2005), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2008) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2009), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2009) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2011), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2014) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 624, DateTimeKind.Utc).AddTicks(5657), new DateTime(2026, 8, 27, 14, 20, 23, 624, DateTimeKind.Utc).AddTicks(5657) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "4e8e5864-bc4c-4301-916d-6e4cf764eb40");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "2a85b8b3-b786-4927-a86d-e7793c53b436");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 636, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 8, 27, 14, 20, 23, 636, DateTimeKind.Utc).AddTicks(7527) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 639, DateTimeKind.Utc).AddTicks(1838), new DateTime(2026, 8, 27, 14, 20, 23, 639, DateTimeKind.Utc).AddTicks(1840) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5155), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5159) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5671), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5671) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5673), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5673) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5675), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5675) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5683), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5684) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5829), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5829) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5830), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5831) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5835) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5836), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5836) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5685), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5686) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5687), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5687) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5688), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5688) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5690), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5690) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5819), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5819) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5821), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5821) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5822), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5822) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5826), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5826) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5827), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5828) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5832), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5832) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5833) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8621), new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8622) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8840), new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8841) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8843), new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8843) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(8684), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(8690) });

        migrationBuilder.CreateIndex(
            name: "IX_product_saleschannel_SalesChannelId_RemoteProductId",
            table: "product_saleschannel",
            columns: new[] { "SalesChannelId", "RemoteProductId" });

        migrationBuilder.CreateIndex(
            name: "IX_customer_CustomerId_TenantId",
            table: "customer",
            columns: new[] { "CustomerId", "TenantId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_customer_TenantId_Email",
            table: "customer",
            columns: new[] { "TenantId", "Email" },
            unique: true,
            filter: "\"Email\" IS NOT NULL AND \"Email\" <> ''");

        migrationBuilder.CreateIndex(
            name: "IX_saleschannel_operation_state_NextDueAt",
            table: "saleschannel_operation_state",
            column: "NextDueAt");

        migrationBuilder.CreateIndex(
            name: "IX_saleschannel_operation_state_SalesChannelId_Operation",
            table: "saleschannel_operation_state",
            columns: new[] { "SalesChannelId", "Operation" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_saleschannel_operation_state_TenantId",
            table: "saleschannel_operation_state",
            column: "TenantId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "saleschannel_operation_state");

        migrationBuilder.DropIndex(
            name: "IX_product_saleschannel_SalesChannelId_RemoteProductId",
            table: "product_saleschannel");

        migrationBuilder.DropIndex(
            name: "IX_customer_CustomerId_TenantId",
            table: "customer");

        migrationBuilder.DropIndex(
            name: "IX_customer_TenantId_Email",
            table: "customer");

        migrationBuilder.DropColumn(
            name: "HeartbeatAt",
            table: "channel_sync_run");

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(835), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1561), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1561) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1564), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1566), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1576), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1576) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1577), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1578) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1579) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1581), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1582) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1583), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1583) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1585), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1585) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1586) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1588), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1588) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1591) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1592), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1593) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1594), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1595), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1596) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1605), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1606) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1607), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1607) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1609) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1610), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1610) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1613), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1613) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1616) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1617), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1619), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1619) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1621), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1621) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1623), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1626), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1626) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1627), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1628) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1629), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1629) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1630), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1631) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1639), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1639) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1640), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1640) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1642), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1642) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1643), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1646), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1646) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1647), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1648) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1649), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1649) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1650), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1650) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1652), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1652) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1653) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1654), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1655) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1656) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1658), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1659) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1673), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1673) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1675), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1675) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1676) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1684), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1684) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1686), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1686) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1687), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1687) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1689), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1689) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1691), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1692) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1693), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1693) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1695) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1696), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1696) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1698) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1699), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1701) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1705), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1705) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1706), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1706) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1707), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1708) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1709), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1709) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1717), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1717) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1718), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1719) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1720), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1720) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1721), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1722) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1724), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1724) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1726), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1726) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1727), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1727) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1729), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1730) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1731), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1732) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1733), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1733) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1734), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1734) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1737), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1737) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1740) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1741), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1741) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1749), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1749) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1750) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1752), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1752) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1753), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1753) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1756), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1757), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1757) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1759), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1759) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1760) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1762), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1762) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1764), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1765) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1766), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1768), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1770) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1771), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1773), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1780) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1782) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1783), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1783) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1785), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1785) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1787), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1787) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1789) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1790), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1790) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1792), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1792) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1793), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1793) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1794), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1796), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1796) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1801), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1804), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1812) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1813), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1815) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1816), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1816) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1819), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1819) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1820), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1821), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1823), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1823) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1824), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1825) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1826), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1827), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1829), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1831), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1831) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1833) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1834), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1834) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1836), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1836) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1843), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1845), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1845) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1847), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1847) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1848), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1851), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1851) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1854), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1855), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1857), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1858), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1859) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1865) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1866), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1866) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1869), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1870), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1870) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1872), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1873), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1881), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1881) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1882) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1884), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1884) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1885), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1886) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1888), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1889), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1893), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1894), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1896), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1897), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1897) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1898), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1899) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1902), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1904), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1904) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1905), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1913), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1914), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1914) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1916), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1917), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1917) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1920) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1921), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1923) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1924), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1924) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1925), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1926) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1927), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1928), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1929) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1930), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1932), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1934), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1935), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1937), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1937) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1946), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1947), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1947) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1952), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1953), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1955), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1955) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1958) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1959) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1961) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1962), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1962) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1965), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1966), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1966) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1969), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1969) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1976), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1977) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1978), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1980) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1981), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1983), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1984) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1985), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1985) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1987), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1988), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1988) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1991), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1991) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1993), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1994), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1997), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1997) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1998), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2000), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2009) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2010), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2016), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2016) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2018) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2019), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2021), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2021) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2024) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2025), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2027), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2027) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2030), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2030) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2031), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2031) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2033), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2034), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2034) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2042), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2045), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2045) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2046) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2049), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2049) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2050), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2052), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2052) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2059), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2059) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2060), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2062), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2062) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2063), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2066), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2067), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2068), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2070), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2071), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2071) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2073), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2074), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2074) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2075), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2076) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2078), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2079) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2080), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2081), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2083) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2084), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2085) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 574, DateTimeKind.Utc).AddTicks(6263), new DateTime(2026, 8, 24, 4, 30, 26, 574, DateTimeKind.Utc).AddTicks(6265) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "fa445e4b-cf57-4983-af0d-ad54fb3935c3");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "7ba26c4e-fa41-4cd2-9429-a258e25ba45b");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 587, DateTimeKind.Utc).AddTicks(9382), new DateTime(2026, 8, 24, 4, 30, 26, 587, DateTimeKind.Utc).AddTicks(9384) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 590, DateTimeKind.Utc).AddTicks(8606), new DateTime(2026, 8, 24, 4, 30, 26, 590, DateTimeKind.Utc).AddTicks(8610) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5013), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5016) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5496), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5497) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5499), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5499) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5507), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5508) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5509), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5509) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5688), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5688) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5689), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5689) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5700), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5701) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5703), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5703) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5510), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5510) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5512), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5512) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5513), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5513) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5514), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5515) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5678), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5678) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5680), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5680) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5683), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5683) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5685), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5685) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5686), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5686) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5690), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5690) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5692), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5692) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1107) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1330) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1332), new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1332) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(6492) });

        migrationBuilder.CreateIndex(
            name: "IX_product_saleschannel_SalesChannelId",
            table: "product_saleschannel",
            column: "SalesChannelId");
    }
}
