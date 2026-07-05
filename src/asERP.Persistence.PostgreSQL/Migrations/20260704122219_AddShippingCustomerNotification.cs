using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingCustomerNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendDeliveryNotificationEmails",
                table: "tenant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendShippingNotificationEmails",
                table: "tenant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerDeliveryNotifiedAt",
                table: "shipping",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerNotifiedAt",
                table: "shipping",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 724, DateTimeKind.Utc).AddTicks(7723), new DateTime(2026, 7, 4, 12, 22, 14, 724, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(651), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(671), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(674), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(678), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(683), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(685), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(687), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(716), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(718), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(721), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(739), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(741), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(744), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(747), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(752), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(756), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(758), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(761), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(773), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(794), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(797), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(801), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(808), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(814), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(817), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(819), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(821), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(827), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(843), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(846), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(848), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(865), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(869), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(871), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(873), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(875), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(877), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(894), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(903), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(908), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(914), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(916), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(958), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(966), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(973), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(975), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(978), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1005), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1010), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1014), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1017), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1019), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1021), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1028), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1042), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1044), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1047), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1054), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1056), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1067), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 726, DateTimeKind.Utc).AddTicks(2851), new DateTime(2026, 7, 4, 12, 22, 14, 726, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "9a41636c-2493-48d3-a363-ad94f51c5eb5");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "aacccb6a-cc73-49aa-9bea-5eed30a92dbd");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 738, DateTimeKind.Utc).AddTicks(8898), new DateTime(2026, 7, 4, 12, 22, 14, 738, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3963), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3963) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3966), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3967), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3969), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3969) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3992), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3993) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3994), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3998), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3999), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3999) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3982), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3982) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3983), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3987), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3988), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3995), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3996), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4612), new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4614) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4818), new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4821), new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified", "SendDeliveryNotificationEmails", "SendShippingNotificationEmails" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 715, DateTimeKind.Utc).AddTicks(5110), new DateTime(2026, 7, 4, 12, 22, 14, 715, DateTimeKind.Utc).AddTicks(5116), false, false });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83ef6ae0-6c75-45ca-a9fa-60613ff4c3c2", new DateTime(2026, 7, 4, 12, 22, 14, 675, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 4, 12, 22, 14, 675, DateTimeKind.Utc).AddTicks(6192), "AQAAAAIAAYagAAAAELWyxMBJCTB/jmH7SOFGwrysvNIWTTAn2/0FVPxhMdaagmKZfwSrNyn1yUzeHDovlg==", "0514403b-5646-43b4-b7e9-0b8fde7ba19a" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 722, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 7, 4, 12, 22, 14, 722, DateTimeKind.Utc).AddTicks(1295), new Guid("5c2f05fe-b3b0-49d5-9308-7af02e4456d0") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(4395) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendDeliveryNotificationEmails",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "SendShippingNotificationEmails",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "CustomerDeliveryNotifiedAt",
                table: "shipping");

            migrationBuilder.DropColumn(
                name: "CustomerNotifiedAt",
                table: "shipping");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4932), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4936), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4946), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4948), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4954), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4955), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4957), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4974), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4976), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4978), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4981), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4983), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4985), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4988), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4991), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4993), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4996), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5023), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5026), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5028), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5032), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5033), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5035), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5037), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5042), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5045), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5047), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5049), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5052), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5063), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5068), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5071), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5073), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5075), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5077), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5082), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5083), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5085), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5087), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5088), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5090), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5092), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5102), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5105), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5107), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5109), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5111), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5113), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5115), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5125), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5128), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5130), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5132), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5135), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5139), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5140), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5152), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5155), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5157), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5159), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5161), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5162), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5164), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5166), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5169), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5171), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5172), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5174), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5176), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5177), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5179), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5181), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5191), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5194), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5195) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5196), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5198), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5200), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5202), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5204), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5206), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5209), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5212), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5214), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5216), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5219), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5221), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5223), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5225), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5228), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5230), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5232), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5234), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5236), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5237), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5239), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5241), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5244), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5246), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5248), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5250), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5251), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5252) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 129, DateTimeKind.Utc).AddTicks(4767), new DateTime(2026, 7, 4, 10, 11, 7, 129, DateTimeKind.Utc).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f7eb7358-45b3-4031-8215-5497c104748f");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4bb15fe9-8e54-457e-9d9e-d752febdf7d2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 143, DateTimeKind.Utc).AddTicks(8983), new DateTime(2026, 7, 4, 10, 11, 7, 143, DateTimeKind.Utc).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(6961), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(6966) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7323), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7339), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7359), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7366), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7368), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7342), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7344) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7354), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7356), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7356) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7362), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7363), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8213), new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8435) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8438), new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 121, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 7, 4, 10, 11, 7, 121, DateTimeKind.Utc).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0626b446-dee4-42e6-9204-7fdfcad23601", new DateTime(2026, 7, 4, 10, 11, 7, 76, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 7, 4, 10, 11, 7, 76, DateTimeKind.Utc).AddTicks(920), "AQAAAAIAAYagAAAAEK0imMei94bqLHdxBFcf7DMSvYrY1uYXOaHIgN/XhlK+G4d5KAet0iRA+Op2ZXbWWw==", "c061a797-b423-4c40-a81f-5f1ee00ac855" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 126, DateTimeKind.Utc).AddTicks(3636), new DateTime(2026, 7, 4, 10, 11, 7, 126, DateTimeKind.Utc).AddTicks(3780), new Guid("20eca17c-2d7a-43ca-8ed9-98f23709d2d2") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(8191) });
        }
    }
}
