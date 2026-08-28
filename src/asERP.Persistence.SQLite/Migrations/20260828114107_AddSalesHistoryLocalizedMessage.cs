using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
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
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageKey",
                table: "sales_history",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 16, DateTimeKind.Utc).AddTicks(8646), new DateTime(2026, 8, 28, 11, 41, 5, 16, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(623), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(638), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(645), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(685), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(693), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(695), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(698), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(703), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(705), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(708), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(725), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(747), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(749), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(757), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(761), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(835), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(835) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(837), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(841), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(843), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(845), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(862), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(865), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(869), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(876), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(879), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(881), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(884), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(891), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(894), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(923), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(926), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(938) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(941), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(943), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(945), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(955), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(965), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(982), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(987), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(992), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(999), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1004), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1008), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1011), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1013), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1015), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1036), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1038), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1043), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1047), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1055), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1059), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1064), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1068), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1071), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1075), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1091), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1093), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1098), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1105), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1108), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1113), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1115), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1122), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1125), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1127), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1129), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1132), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1147), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1149), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1154), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1156), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1159), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1161), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1177), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1189), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1191), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1196), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1201), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1216), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1219), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1226), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1231), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1233), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1237), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1239), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1246), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1249), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1254), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1256), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1258), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1274), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1277), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1284), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1286), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1291), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1294), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1296), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1298), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1303), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1308), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1312), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1315), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1331), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1335), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1342), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1344), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1347), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1349), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1353), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1355), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1358), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1362), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1365), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1367), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1375), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1399), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1402), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1404), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1407), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1412), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1415), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1425), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1433), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1448), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1455), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1458), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1465), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1467), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1472), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1477), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1479), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1481), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1484), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1504), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1507), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1511), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1513), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1524), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1527), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1531), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1533), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1536), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1538), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1542), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1545), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1547), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1549), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1551), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1552) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1554), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1570), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1572), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1576), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1581), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1582) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1584), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1589), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1593), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1601), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1603), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1606), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1612), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1621), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1621) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 19, DateTimeKind.Utc).AddTicks(8178), new DateTime(2026, 8, 28, 11, 41, 5, 19, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7be45078-dcbd-4209-af38-82b3afc79893");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "1bf79fc5-a435-4633-a864-dc1904ecc675");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 82, DateTimeKind.Utc).AddTicks(3431), new DateTime(2026, 8, 28, 11, 41, 5, 82, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 85, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 8, 28, 11, 41, 5, 85, DateTimeKind.Utc).AddTicks(9596) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 153, DateTimeKind.Utc).AddTicks(8982), new DateTime(2026, 8, 28, 11, 41, 5, 153, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(238), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(239) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(244), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(247), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(249), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(670), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(673), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(673) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(252), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(267), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(267) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(269), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(272), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(272) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(625), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(625) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(629), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(629) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(648), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(650), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(666), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(668), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8445), new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8783), new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8787), new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 18, DateTimeKind.Utc).AddTicks(2599), new DateTime(2026, 8, 28, 11, 41, 5, 18, DateTimeKind.Utc).AddTicks(2602) });
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
        }
    }
}
