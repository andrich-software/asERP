using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class NullifyLegacySalesItemShippingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Hand-edited data fix: legacy rows carry Guid.Empty because sales_item.ShippingId was
            // non-nullable before AddShippingFeature — NULL now means "not assigned to a parcel".
            // Runs in its own migration because SQLite defers the nullability rebuild past raw SQL.
            migrationBuilder.Sql("UPDATE sales_item SET ShippingId = NULL WHERE ShippingId = '00000000-0000-0000-0000-000000000000'");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3018), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3667), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3672), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3673), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3675), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3685), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3686), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3688), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3691), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3693), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3694), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3696), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3699), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3701), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3713), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3715), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3716), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3718), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3721), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3724), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3726), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3727), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3729), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3738), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3742), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3743), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3745), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3747), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3749), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3758), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3760), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3762), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3764), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3765) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3766), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3768), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3771), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3772), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3774), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3788), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3791), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3793), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3795), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3797), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3808), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3812), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3814), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3818), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3822), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3823), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3825), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3826), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3828), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3829), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3832), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3833), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3842), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3844), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3846), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3847), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3853), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3856), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3858), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3859), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3861), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3862), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3864), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3866), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3868), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3876), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3879), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3881), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3883), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3884), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3886), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3889), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3891), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3892), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3894), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3895), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3897), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3898), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3903), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3904), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3913), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3915), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3916), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3918), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3922), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3924), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3927), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3929), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3932), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3934), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3936), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3937), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3941), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3943), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3945), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3946), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3948), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3949), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3951), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3955), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 864, DateTimeKind.Utc).AddTicks(3554), new DateTime(2026, 7, 3, 20, 57, 56, 864, DateTimeKind.Utc).AddTicks(3555) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "78f9ca01-5752-42e0-9ef1-c06b897bd052");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "749bccb6-21d5-4be1-966c-aa1d24a36709");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 879, DateTimeKind.Utc).AddTicks(298), new DateTime(2026, 7, 3, 20, 57, 56, 879, DateTimeKind.Utc).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9457), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9813), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9814) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9817), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9819), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9829), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9852), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9853), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9858), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9859), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9831), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9832), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9833) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9834), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9835), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9837), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9845), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9846), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9849), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9849) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9851), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9851) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9855), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9856), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9856) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7023), new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7024) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7229), new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 856, DateTimeKind.Utc).AddTicks(1858), new DateTime(2026, 7, 3, 20, 57, 56, 856, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a254cd74-6799-48f1-902f-0d0d31b73312", new DateTime(2026, 7, 3, 20, 57, 56, 814, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 7, 3, 20, 57, 56, 814, DateTimeKind.Utc).AddTicks(393), "AQAAAAIAAYagAAAAEPQloBXVxOJE3xmwpGSbxV8UkxxTlie6Dj/t5Cc89byunMIiePLs6uHReqoW2I3ZjQ==", "204c6310-31b3-42e0-96e9-934e59b9420d" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 861, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 7, 3, 20, 57, 56, 861, DateTimeKind.Utc).AddTicks(2573), new Guid("df0ae092-ad6a-4486-b17b-292065973647") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(7262), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(7263) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(8376), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9042), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9046), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9047), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9049), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9051), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9059), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9061), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9063), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9064), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9065) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9066), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9081), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9083), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9087), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9088), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9100), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9102), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9104), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9106), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9108), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9114), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9116), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9118), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9132), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9138), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9142), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9142) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9145), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9146), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9146) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9155), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9157), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9159), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9162), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9163), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9165), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9168), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9172), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9173), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9175), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9177), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9178), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9180), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9183), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9185), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9195), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9197), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9202), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9205), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9208), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9212), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9213), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9215), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9217), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9218), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9223), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9233), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9236), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9238), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9241), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9243), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9246), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9248), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9251), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9253), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9255), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9258), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9261), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9263), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9274), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9276), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9278), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9281), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9284), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9286), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9288), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9289), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9291), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9293), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9294), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9296), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9299), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9300), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9309), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9312), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9314), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9316), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9318), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9324), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9325), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9332), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9334), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9337), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9339), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9341), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9343), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9345), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9347), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9349), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9352), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9354), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9355), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9357), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9362), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9362) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(9399), new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "ea074e70-97c7-47e5-be3e-49411513fcaf");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ff8f6e2d-8b5e-4fab-bebc-f3d3afaab083");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 716, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 7, 3, 19, 26, 9, 716, DateTimeKind.Utc).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3595), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3598) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3974), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3975) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3984) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3988), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4006), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4007) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4008), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4014), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4016), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3992), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3993), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3995), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3997), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3997) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4000), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4001), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4002) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4003), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4005), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4009), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4011), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(7857), new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(7859) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8145), new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8145) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8147), new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8147) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 696, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 7, 3, 19, 26, 9, 696, DateTimeKind.Utc).AddTicks(2776) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a29cb451-f76a-4985-8cdc-a32454c417b2", new DateTime(2026, 7, 3, 19, 26, 9, 653, DateTimeKind.Utc).AddTicks(9155), new DateTime(2026, 7, 3, 19, 26, 9, 653, DateTimeKind.Utc).AddTicks(9159), "AQAAAAIAAYagAAAAEMrRd1y0pgQRGoDdtiaqwPs6kXwA6cH5ZZEAHWtAqJVdWZlceYjDqkD0j6zoOIukIw==", "48a20bc8-4ccc-48b0-aa98-d1bdf00f701f" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 700, DateTimeKind.Utc).AddTicks(7544), new DateTime(2026, 7, 3, 19, 26, 9, 700, DateTimeKind.Utc).AddTicks(7670), new Guid("b9c214ca-64a2-4e77-83ca-30d564b089ca") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(2659), new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(2660) });
        }
    }
}
