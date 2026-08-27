using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations;

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
            type: "TEXT",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "saleschannel_operation_state",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                Operation = table.Column<int>(type: "INTEGER", nullable: false),
                Phase = table.Column<int>(type: "INTEGER", nullable: false),
                NextDueAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                CurrentIntervalSeconds = table.Column<int>(type: "INTEGER", nullable: false),
                ConsecutiveFailures = table.Column<int>(type: "INTEGER", nullable: false),
                Watermark = table.Column<DateTime>(type: "TEXT", nullable: true),
                CursorDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                CursorPage = table.Column<int>(type: "INTEGER", nullable: false),
                CursorText = table.Column<string>(type: "TEXT", maxLength: 400, nullable: true),
                LastStartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                LastSuccessAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                LastFullSweepAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
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
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(5889), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(5894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6572), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6572) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6575), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6575) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6577), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6577) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6578), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6579) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6580), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6580) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6588), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6589) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6590), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6590) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6592), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6592) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6593), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6607), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6607) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6609), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6609) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6610), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6610) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6612), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6612) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6615), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6616), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6617) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6618), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6620), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6620) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6621), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6621) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6623), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6623) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6624), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6625) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6626), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6626) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6641), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6642) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6643), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6645), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6645) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6646), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6647) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6655), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6655) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6656), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6657) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6658), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6658) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6669), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6669) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6675), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6675) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6677), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6677) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6678), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6679) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6680), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6680) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6682), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6682) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6683), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6683) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6685), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6685) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6687), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6687) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6689), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6690) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6691), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6691) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6693), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6693) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6694), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6694) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6702), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6703) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6704), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6705) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6706), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6706) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6708), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6708) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6711), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6711) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6712), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6713) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6714), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6714) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6716), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6716) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6717), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6718) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6719), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6719) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6721), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6722), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6722) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6725), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6725) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6727), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6727) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6728), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6728) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6730) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6738), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6740) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6741), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6742) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6743), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6743) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6746), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6746) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6747), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6748) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6749), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6749) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6751), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6751) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6752), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6752) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6754), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6754) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6756), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6757), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6757) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6760) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6762), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6762) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6763), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6765), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6765) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6772), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6775), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6775) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6776), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6777) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6778) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6781) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6782), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6783) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6784), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6784) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6786), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6786) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6787), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6787) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6789), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6789) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6791) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6792), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6792) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6795), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6796), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6798), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6798) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6799), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6807), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6809), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6812), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6812) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6813), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6816), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6816) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6818), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6818) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6819), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6819) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6821), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6821) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6822), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6823) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6824), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6826), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6827), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6831), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6832) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6833), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6833) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6834), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6835) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6842), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6842) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6844), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6844) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6846), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6847), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6852), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6853), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6855), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6855) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6856), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6862), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6863) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6864), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6864) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6866), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6866) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6869), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6870) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6872), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6873), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6874) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6881), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6881) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6883), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6884) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6885), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6885) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6887), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6887) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6890), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6891), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6891) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6893), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6894), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6896), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6897), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6898) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6899), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6899) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6903), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6905), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6906), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6906) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6908), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6908) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6915), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6919), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6919) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6922), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6922) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6925), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6926), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6928), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6928) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6931), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6933), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6933) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6934), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6936), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6936) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6938), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6939) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6940) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6941), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6942) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6943), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6943) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6951), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6953), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6954), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6956), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6959), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6959) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6960) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6962), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6962) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6963), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6963) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6965), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6967), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6967) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6968), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6969) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6970) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6973), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6973) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6974), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6975) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6976), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6976) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6977), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6985), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6986) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6988), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6988) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6991), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6994), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6996), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6997), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6999), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(6999) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7002), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7004), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7005), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7008), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7008) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7009), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7009) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7011), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7012), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7021) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7023), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7023) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7024), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7026), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7026) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7029), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7029) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7030) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7032), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7032) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7033), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7034) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7035), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7035) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7037), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7038), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7038) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7040) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7043), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7044), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7044) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7046), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7046) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7047), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7055), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7058), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7058) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7061), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7061) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7064), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7064) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7065), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7071), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7073), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7075), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7076), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7077) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7078), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7078) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7079), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7082), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7084), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7085), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7085) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7087), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7087) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7095), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7096), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7096) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7098), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7098) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7100) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7102), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7104), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7104) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7106), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7106) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7107), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7107) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7109), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7109) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7111) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7112), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7112) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7114), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7114) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7117), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7118) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7119), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7119) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7121) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7122), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7122) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7130) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7132), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7134), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7134) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7135), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7136) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7138) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7140) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7141), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7142) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7143) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7144), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7146), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7146) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7148), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7149), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7149) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7152), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7153), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7154) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7155), new DateTime(2026, 8, 27, 14, 20, 40, 101, DateTimeKind.Utc).AddTicks(7155) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 102, DateTimeKind.Utc).AddTicks(8139), new DateTime(2026, 8, 27, 14, 20, 40, 102, DateTimeKind.Utc).AddTicks(8140) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "66c097f9-2aa9-4c10-87dc-04a4875eff4e");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "8639b129-eda2-49f1-9b28-98531bb4cb57");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 114, DateTimeKind.Utc).AddTicks(4354), new DateTime(2026, 8, 27, 14, 20, 40, 114, DateTimeKind.Utc).AddTicks(4358) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 116, DateTimeKind.Utc).AddTicks(7417), new DateTime(2026, 8, 27, 14, 20, 40, 116, DateTimeKind.Utc).AddTicks(7418) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3187), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3190) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3693), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3694) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3696), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3697) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3698), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3699) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3701) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3848), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3848) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3849) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3854), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3854) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3855) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3702), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3702) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3710) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3712), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3712) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3713), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3713) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3838), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3838) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3840) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3841), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3842) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3843), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3843) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3844), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3845) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3851), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3851) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3852), new DateTime(2026, 8, 27, 14, 20, 40, 148, DateTimeKind.Utc).AddTicks(3852) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 119, DateTimeKind.Utc).AddTicks(2631), new DateTime(2026, 8, 27, 14, 20, 40, 119, DateTimeKind.Utc).AddTicks(2632) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 119, DateTimeKind.Utc).AddTicks(2865), new DateTime(2026, 8, 27, 14, 20, 40, 119, DateTimeKind.Utc).AddTicks(2866) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 119, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 8, 27, 14, 20, 40, 119, DateTimeKind.Utc).AddTicks(2868) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 27, 14, 20, 40, 102, DateTimeKind.Utc).AddTicks(1412), new DateTime(2026, 8, 27, 14, 20, 40, 102, DateTimeKind.Utc).AddTicks(1414) });

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
            filter: "Email IS NOT NULL AND Email <> ''");

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
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(1193), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(1198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4232) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4235) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4245) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4251) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4253), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4255), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4258) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4281), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4281) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4286), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4286) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4306) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4308), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4311) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4313), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4315), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4320) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4325) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4328) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4330) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4332), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4333) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4340) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4346), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4348), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4348) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4351), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4365), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4365) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4368), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4368) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4370) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4372), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4373) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4375), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4377), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4378) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4380) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4383), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4387), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4387) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4389), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4390) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4392), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4394) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4396), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4396) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4398), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4401) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4403), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4403) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4416), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4417) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4442), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4445), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4445) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4447), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4452), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4454), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4457), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4457) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4461), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4463), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4466), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4466) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4468), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4468) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4471) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4473), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4473) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4475), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4475) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4477), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4478) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4491), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4491) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4493), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4494) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4496), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4496) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4498), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4498) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4500) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4502), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4503) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4505), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4505) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4507), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4511), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4511) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4513), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4514) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4515), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4518), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4518) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4521) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4522), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4524), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4525) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4527), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4527) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4541) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4543), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4543) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4545), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4545) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4547), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4547) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4549), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4549) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4551), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4552) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4553), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4554) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4555), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4556) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4560), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4560) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4562), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4562) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4564), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4566), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4568), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4568) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4570), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4571) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4573), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4573) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4575) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4589), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4590) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4591), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4592) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4594), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4596), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4597) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4598), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4599) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4601) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4603), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4603) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4605), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4605) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4609), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4609) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4611), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4611) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4613), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4613) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4615), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4617), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4619), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4620) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4621), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4624), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4638), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4638) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4641) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4643), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4645), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4645) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4647), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4647) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4649), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4650) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4652), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4652) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4654), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4654) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4658), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4658) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4660) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4662), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4663) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4667), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4667) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4669), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4669) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4671), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4672) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4673), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4674) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4676), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4676) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4690) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4692), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4692) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4694), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4695) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4697), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4697) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4699), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4701), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4704), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4704) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4706), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4706) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4710), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4710) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4712), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4712) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4714), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4714) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4716), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4717) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4718), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4719) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4729), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4731), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4731) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4745), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4746) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4748), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4748) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4751), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4752) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4753), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4754) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4756), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4758), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4758) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4760), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4761) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4762), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4766), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4767) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4769), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4771), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4773), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4775), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4775) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4777), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4777) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4779), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4780) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4781), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4782) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4795), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4797), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4799), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4799) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4801), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4803), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4805), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4807), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4808) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4810) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4814), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4814) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4817), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4817) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4819), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4821), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4823), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4826), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4828), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4828) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4845), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4847), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4852), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4856), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4858), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4858) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4861) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4864), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4865) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4867) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4869), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4871), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4871) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4875), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4877), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4877) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4879), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4879) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4883), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4883) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4896), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4898), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4898) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4900) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4902), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4904), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4906), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4907) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4909), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4909) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4912), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4914), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4917), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4917) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4919), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4919) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4921), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4923), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4923) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4925), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4927), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4931), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4943), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4945), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4947), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4948) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4954), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4956), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4960) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4963), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4963) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4965), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4967), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4969), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4970) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4972), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4972) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4974), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4974) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4976), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4977) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4993), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5002), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5004), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5006), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5007) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5012), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5013) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5015), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5015) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5023), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5023) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5025), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5027), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5028) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5029), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5029) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5031) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5034), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5034) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5035), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5035) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5037), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5038), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5038) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5039) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5041), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5041) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5042), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5044) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(7706), new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(7707) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "a17bf52e-042d-467b-8f3e-3a03204d181e");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "1e4b0b53-f47f-42ad-8414-8f9d8b110d49");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 702, DateTimeKind.Utc).AddTicks(8127), new DateTime(2026, 8, 24, 4, 30, 12, 702, DateTimeKind.Utc).AddTicks(8131) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 705, DateTimeKind.Utc).AddTicks(2453), new DateTime(2026, 8, 24, 4, 30, 12, 705, DateTimeKind.Utc).AddTicks(2455) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(725) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1238), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1239) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1242) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1244), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1244) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1246), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1246) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1395) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1396), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1396) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1408), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1408) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1410) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1247) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1248), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1249) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1250) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1251) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1387), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1387) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1389), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1389) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1390) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1391), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1392) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1393), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1393) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1398) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1400) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(4913), new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(4918) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5142), new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5142) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5144), new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5144) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(638), new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(639) });

        migrationBuilder.CreateIndex(
            name: "IX_product_saleschannel_SalesChannelId",
            table: "product_saleschannel",
            column: "SalesChannelId");
    }
}
