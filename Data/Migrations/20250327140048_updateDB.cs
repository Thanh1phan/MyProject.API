using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.API.Migrations.Data
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M01Cs");

            migrationBuilder.CreateTable(
                name: "B03T",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B03T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "K02T",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    M01CId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K02T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "K11T",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    M01CId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZOBAIKA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZIBAIKA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K11T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M01C",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    B3CD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M01C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M02T",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    M01CID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SEQ = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ZOBAIKA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZIBAIKA = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M02T", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B03T");

            migrationBuilder.DropTable(
                name: "K02T");

            migrationBuilder.DropTable(
                name: "K11T");

            migrationBuilder.DropTable(
                name: "M01C");

            migrationBuilder.DropTable(
                name: "M02T");

            migrationBuilder.CreateTable(
                name: "M01Cs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    B3CD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2025, 3, 16, 14, 12, 56, 135, DateTimeKind.Local).AddTicks(3602)),
                    DId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2025, 3, 16, 14, 12, 56, 140, DateTimeKind.Local).AddTicks(3674))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M01Cs", x => x.Id);
                });
        }
    }
}
