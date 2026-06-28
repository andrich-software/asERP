using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialCustomerImportCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7260), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7280), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 941, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 6, 9, 20, 52, 54, 941, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "94ef4b05-1670-49e3-a863-725f9f0e0072");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ff56f7cd-0dbd-4dc8-aa8b-68fc3afd3124");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "InitialCustomerImportCompleted" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 949, DateTimeKind.Utc).AddTicks(8830), new DateTime(2026, 6, 9, 20, 52, 54, 949, DateTimeKind.Utc).AddTicks(8830), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(8950), new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 934, DateTimeKind.Utc).AddTicks(7380), new DateTime(2026, 6, 9, 20, 52, 54, 934, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd8b7a5d-8484-41f4-9853-551e60978080", new DateTime(2026, 6, 9, 20, 52, 54, 897, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 20, 52, 54, 897, DateTimeKind.Utc).AddTicks(3010), "AQAAAAIAAYagAAAAEHznxZcJTi9X1K43uejo7smk2cbvUGwAhyWWB1oVXGi2GYmY7zD5OAN6o2iZirI12A==", "81e4f522-df7f-4191-a878-6f0bb8de18d3" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 938, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 9, 20, 52, 54, 938, DateTimeKind.Utc).AddTicks(3380), new Guid("de228155-e032-48ef-afe9-adf44e502b6d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(8940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(8940) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(5640), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6020), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6060), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6060), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6060), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6080), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6080), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6080), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6110), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6110), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6110), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6130), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6130), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6130), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6180), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6350), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6350), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6350), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 706, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 6, 9, 12, 53, 3, 706, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "e8ae7fff-11dd-4721-a168-547bdee4c37d");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "02b482e7-1204-41e3-85d1-eeaeede5fefc");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 714, DateTimeKind.Utc).AddTicks(3560), new DateTime(2026, 6, 9, 12, 53, 3, 714, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8220), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8480), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 6, 9, 12, 53, 3, 722, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 715, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 6, 9, 12, 53, 3, 715, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 715, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 6, 9, 12, 53, 3, 715, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 715, DateTimeKind.Utc).AddTicks(3610), new DateTime(2026, 6, 9, 12, 53, 3, 715, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 700, DateTimeKind.Utc).AddTicks(620), new DateTime(2026, 6, 9, 12, 53, 3, 700, DateTimeKind.Utc).AddTicks(630) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4f59372-a9f7-455a-a3b4-ea907668d852", new DateTime(2026, 6, 9, 12, 53, 3, 664, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 9, 12, 53, 3, 664, DateTimeKind.Utc).AddTicks(3880), "AQAAAAIAAYagAAAAEP4R/aJ7b1cGBOy6CZ84PDS5Rs5GIcvNVuRh8eU/CIOns9CDGYK46QPxaro3VI2ahQ==", "64f803db-6917-4a66-876e-07d07752e863" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 703, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 6, 9, 12, 53, 3, 703, DateTimeKind.Utc).AddTicks(2770), new Guid("b46be99a-77b0-4ee8-8065-9f15ab808745") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 12, 53, 3, 705, DateTimeKind.Utc).AddTicks(7850) });
        }
    }
}
