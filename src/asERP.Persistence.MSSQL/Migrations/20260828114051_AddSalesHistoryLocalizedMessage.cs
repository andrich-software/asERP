using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesHistoryLocalizedMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageArgs",
                table: "sales_history",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageKey",
                table: "sales_history",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 733, DateTimeKind.Utc).AddTicks(9027), new DateTime(2026, 8, 28, 11, 40, 50, 733, DateTimeKind.Utc).AddTicks(9031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(605), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(613), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(616), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(643), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(647), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(649), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(656), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(665), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(669), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(671), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(694), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(698), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(714), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(718), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(724), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(744), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(746), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(772), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(778), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(785), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(787), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(789), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(791), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(848), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(859), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(861), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(863), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(868), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(877), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(889), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(891), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(902), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(904), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(906), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(908), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(917), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(942), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(954), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(963), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(975), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(977), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(981), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(983), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(985), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(993), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(995), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(999), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1028), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1031), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1038), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1042), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1044), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1048), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1062), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1068), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1071), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1075), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1077), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1079), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1081), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1086), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1088), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1092), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1104), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1106), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1108), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1114), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1116), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1133), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1135), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1137), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1142), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1156), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1158), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1162), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1166), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1172), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1174), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1176), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1178), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1185), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1202), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1204), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1206), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1208), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1212), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1215), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1217), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1219), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1221), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1225), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1238), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1243), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1245), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1249), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1253), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1256), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1258), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1262), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1264), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1283), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1285), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1287), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1292), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1294), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1296), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1298), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1302), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1308), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1311), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1323), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1325), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1326), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1328), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1331), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1333), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1337), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1341), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1343), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1345), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1347), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1349), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1351), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1364), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1366), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1368), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1374), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1376), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1378), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1381), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1383), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1385), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1387), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1389), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1405), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1418), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1424), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1426), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1434), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1437), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1439), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1441), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1443), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1445), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1447), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 736, DateTimeKind.Utc).AddTicks(3177), new DateTime(2026, 8, 28, 11, 40, 50, 736, DateTimeKind.Utc).AddTicks(3178) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7fa1ab9a-979e-41b2-a368-fc5bdcf24a04");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6d11c143-f6a2-4385-bf19-f83f8a5a5ccd");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 753, DateTimeKind.Utc).AddTicks(6195), new DateTime(2026, 8, 28, 11, 40, 50, 753, DateTimeKind.Utc).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 757, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 8, 28, 11, 40, 50, 757, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1096), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1765), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1775), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1776) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1954), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1954) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1956) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1963), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1964) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1778), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1779), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1781), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1783), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1940), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1943), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1945), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1950), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1952), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1952) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5138), new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5140) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5399), new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5403), new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5403) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 735, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 8, 28, 11, 40, 50, 735, DateTimeKind.Utc).AddTicks(1383) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageArgs",
                table: "sales_history");

            migrationBuilder.DropColumn(
                name: "MessageKey",
                table: "sales_history");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 827, DateTimeKind.Utc).AddTicks(9718), new DateTime(2026, 8, 27, 14, 20, 6, 827, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(404), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(415), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(417), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(419), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(422), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(423), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(425), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(427), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(432), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(433), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(444), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(448), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(451), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(454), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(456), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(457), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(459), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(462), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(462) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(463), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(465), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(468), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(469), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(471), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(471) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(488), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(492), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(494), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(495), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(497), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(500), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(501), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(503), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(504), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(506), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(507), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(509), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(510), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(513), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(515), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(516), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(526), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(527), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(529), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(531), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(533), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(536), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(538), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(539), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(541), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(543), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(544), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(546), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(559), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(559) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(562), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(564), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(565), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(565) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(573), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(576), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(577), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(578) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(579), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(580), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(581) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(583), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(585), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(586), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(589), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(591), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(592), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(594), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(597), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(598), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(600), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(607), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(612), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(613), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(615), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(618), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(619), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(621), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(623), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(624), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(626), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(627), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(627) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(629), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(629) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(631), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(632) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(633), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(635) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(643) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(644), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(646), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(647), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(649), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(652), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(652) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(655), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(656), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(659), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(662), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(665), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(668), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(677), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(682), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(685), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(687), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(688), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(690), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(691), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(693), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(694), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(699), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(702), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(709), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(711), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(715), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(716), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(719), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(723), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(725), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(729), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(732), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(735), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(743), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(745), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(747), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(754) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(756), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(756) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(757), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(773), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(781), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(782), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(784), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(787), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(796), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(798), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(801), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(801) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(803), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(805), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(814), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(816), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(818), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(819), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(821), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(826), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(827) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(828), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(831), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(834), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(837), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(838), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(847), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(849), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(854), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(854) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(862), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(863), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(865), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(866), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(868), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(873), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(882), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(884), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(886), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(889), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(892), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(895), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(902), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(907), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(909), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(916), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(919), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(921), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(928), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(931), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(934), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(939), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(940), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(941), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(954), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(959), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(966), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(966) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(969), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(972), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(972) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 829, DateTimeKind.Utc).AddTicks(1869), new DateTime(2026, 8, 27, 14, 20, 6, 829, DateTimeKind.Utc).AddTicks(1870) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "582aae7e-9a65-434d-9ea6-876cc3bcf723");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2bbf0b24-3a8f-4a7f-9157-a098a4d26f6f");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 840, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 8, 27, 14, 20, 6, 840, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 842, DateTimeKind.Utc).AddTicks(6405), new DateTime(2026, 8, 27, 14, 20, 6, 842, DateTimeKind.Utc).AddTicks(6407) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2507), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2511), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2512) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2515), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2518), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2518) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2792), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2792) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2798), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2798) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2799), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2522), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2533), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2534) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2536), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2536) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2538), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2776) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2778), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2782), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2783) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2785), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2785) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2794), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2795), new DateTime(2026, 8, 27, 14, 20, 6, 875, DateTimeKind.Utc).AddTicks(2796) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 845, DateTimeKind.Utc).AddTicks(1837), new DateTime(2026, 8, 27, 14, 20, 6, 845, DateTimeKind.Utc).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 845, DateTimeKind.Utc).AddTicks(2055), new DateTime(2026, 8, 27, 14, 20, 6, 845, DateTimeKind.Utc).AddTicks(2056) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 845, DateTimeKind.Utc).AddTicks(2058), new DateTime(2026, 8, 27, 14, 20, 6, 845, DateTimeKind.Utc).AddTicks(2058) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(5347), new DateTime(2026, 8, 27, 14, 20, 6, 828, DateTimeKind.Utc).AddTicks(5348) });
        }
    }
}
