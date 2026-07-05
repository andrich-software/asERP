using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendShippingNotificationEmails",
                table: "tenant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerDeliveryNotifiedAt",
                table: "shipping",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerNotifiedAt",
                table: "shipping",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(2394), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3223), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3225), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3227), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3228), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3242), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3252), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3254), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3255), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3257), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3259), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3267), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3269), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3273), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3275), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3277), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3282), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3283), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3294), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3299), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3301), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3308), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3312), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3314), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3316), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3317), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3319), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3324), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3326), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3328), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3329), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3331), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3333), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3342), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3346), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3348), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3352), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3353), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3355), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3357), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3358), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3361), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3363), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3365), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3366), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3368), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3372), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3381), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3385), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3387), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3389), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3391), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3392), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3394), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3396), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3397), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3401), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3401) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3402), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3404), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3406), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3407), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3418), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3419), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3435), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3436), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3438), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3442), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3443), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3445), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3447), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3452), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3453), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3455), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3457), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3471), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3478), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3482), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3484), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3485), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3487), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3489), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3492), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3493), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3495), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3497), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3498), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3502), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3515), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3517), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3518), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3522), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3524), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3525), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3527), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3530), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3532), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3533), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3535), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3535) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3537), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3538), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3541), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 957, DateTimeKind.Utc).AddTicks(3667), new DateTime(2026, 7, 4, 12, 20, 42, 957, DateTimeKind.Utc).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "3a0842a0-f640-44e4-ab3b-218d2435240e");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d9cb0686-7bf5-4b48-9377-9bae53af7eb7");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 970, DateTimeKind.Utc).AddTicks(4225), new DateTime(2026, 7, 4, 12, 20, 42, 970, DateTimeKind.Utc).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(742), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1148), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1148) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1158), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1162), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1162) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1166), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1166) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1167), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1171), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1174), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1174) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1175), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1177), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1177) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1179), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1179) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1183), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1185), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(1893) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2122), new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2125), new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified", "SendDeliveryNotificationEmails", "SendShippingNotificationEmails" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 948, DateTimeKind.Utc).AddTicks(4171), new DateTime(2026, 7, 4, 12, 20, 42, 948, DateTimeKind.Utc).AddTicks(4174), false, false });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e54fe31-a748-48e8-b8f1-aa139cf2258b", new DateTime(2026, 7, 4, 12, 20, 42, 899, DateTimeKind.Utc).AddTicks(6026), new DateTime(2026, 7, 4, 12, 20, 42, 899, DateTimeKind.Utc).AddTicks(6031), "AQAAAAIAAYagAAAAEBAiF1xerHYWZNNte1bvQJpj4fmvU9gvsYEerY3AEy3r4OU59KhE+1W6OiqK+nDkNw==", "7e7c48f4-0971-4568-b47e-6095363ed5b5" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 954, DateTimeKind.Utc).AddTicks(246), new DateTime(2026, 7, 4, 12, 20, 42, 954, DateTimeKind.Utc).AddTicks(390), new Guid("30e53717-4db8-404b-9ba8-1c2120a7a2c4") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(6622), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(6623) });
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
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(2527), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(2529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3229), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3231), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3234), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3235), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3237), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3238), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3244), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3246), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3247), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3249), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3251), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3257), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3269), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3273), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3275), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3277), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3281), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3283), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3284), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3287), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3288), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3294), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3298), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3301), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3303), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3312), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3316), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3317), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3319), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3323), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3325), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3326), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3329), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3331), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3332), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3333), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3335), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3336), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3338), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3346), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3352), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3353), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3355), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3356), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3358), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3359), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3361), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3364), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3373), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3375), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3376), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3378), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3379), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3381), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3389), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3393), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3395), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3397), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3398), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3401), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3401) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3403), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3404), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3407), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3408), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3411), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3413), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3414), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3416), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3424), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3428), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3431), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3433), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3434), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3436), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3437), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3439), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3441), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3443), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3444), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3446), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3447), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3449), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3459), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3462), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3462) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3464), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3465), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3467), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3468), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3470), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3471), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3474), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3478), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3482), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3483), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3484), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3486), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3487), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3490), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3491), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3493), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3494), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3496), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3496) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3497), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3499), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(3501) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 186, DateTimeKind.Utc).AddTicks(2738), new DateTime(2026, 7, 4, 10, 10, 36, 186, DateTimeKind.Utc).AddTicks(2739) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "adac369d-6bc1-44f3-a9bb-3166de8146cd");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6d847163-5d93-4d38-b251-ec5ebcff6d0a");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 199, DateTimeKind.Utc).AddTicks(292), new DateTime(2026, 7, 4, 10, 10, 36, 199, DateTimeKind.Utc).AddTicks(296) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2505), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2873), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2873) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2875) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2876), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2898), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2899) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2900), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2904), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2905), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2906) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2887), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2888), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2890), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2891), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2891) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2893), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2894), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2895) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2896), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2901), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2903), new DateTime(2026, 7, 4, 10, 10, 36, 223, DateTimeKind.Utc).AddTicks(2903) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 200, DateTimeKind.Utc).AddTicks(6342), new DateTime(2026, 7, 4, 10, 10, 36, 200, DateTimeKind.Utc).AddTicks(6343) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 200, DateTimeKind.Utc).AddTicks(6550), new DateTime(2026, 7, 4, 10, 10, 36, 200, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 200, DateTimeKind.Utc).AddTicks(6552), new DateTime(2026, 7, 4, 10, 10, 36, 200, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 178, DateTimeKind.Utc).AddTicks(3296), new DateTime(2026, 7, 4, 10, 10, 36, 178, DateTimeKind.Utc).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ef71fe8-f6a5-47c7-9d58-a036e25b48fb", new DateTime(2026, 7, 4, 10, 10, 36, 137, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 7, 4, 10, 10, 36, 137, DateTimeKind.Utc).AddTicks(6974), "AQAAAAIAAYagAAAAEHMbXivOJvfulukr3bFwHNic2RDtzYCM/5od+oF+iGtOIGUb5QycltNuDOWSJblPig==", "ed376e70-ebc8-453d-872f-0bc7139bef18" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 183, DateTimeKind.Utc).AddTicks(2178), new DateTime(2026, 7, 4, 10, 10, 36, 183, DateTimeKind.Utc).AddTicks(2307), new Guid("16b32385-bde2-4e92-9e2f-44cd5367ad7f") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(6295), new DateTime(2026, 7, 4, 10, 10, 36, 185, DateTimeKind.Utc).AddTicks(6296) });
        }
    }
}
