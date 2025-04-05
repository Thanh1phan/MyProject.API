using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.API.Migrations.Data
{
    /// <inheritdoc />
    public partial class edit_table_m01c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "M01C");

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "K02T",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seq",
                table: "K02T");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "M01C",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
