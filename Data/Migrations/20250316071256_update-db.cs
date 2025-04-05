using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.API.Migrations.Data
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "M01Cs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 16, 14, 12, 56, 140, DateTimeKind.Local).AddTicks(3674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "M01Cs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 16, 14, 12, 56, 135, DateTimeKind.Local).AddTicks(3602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "M01Cs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 16, 14, 12, 56, 140, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "M01Cs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 16, 14, 12, 56, 135, DateTimeKind.Local).AddTicks(3602));
        }
    }
}
