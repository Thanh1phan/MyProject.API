using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.API.Migrations.Data
{
    /// <inheritdoc />
    public partial class editDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "M01Cs",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "M01Cs",
                newName: "CreateDate");

            migrationBuilder.AddColumn<Guid>(
                name: "DId",
                table: "M01Cs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "K01T",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K01T", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "K01T");

            migrationBuilder.DropColumn(
                name: "DId",
                table: "M01Cs");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "M01Cs",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "M01Cs",
                newName: "CreateTime");
        }
    }
}
