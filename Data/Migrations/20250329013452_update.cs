using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.API.Migrations.Data
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "B3CD",
                table: "M01C",
                newName: "B3Id");

            migrationBuilder.CreateIndex(
                name: "IX_M02T_M01CID",
                table: "M02T",
                column: "M01CID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_M01C_B3Id",
                table: "M01C",
                column: "B3Id");

            migrationBuilder.CreateIndex(
                name: "IX_K02T_M01CId",
                table: "K02T",
                column: "M01CId");

            migrationBuilder.AddForeignKey(
                name: "FK_K02T_M01C_M01CId",
                table: "K02T",
                column: "M01CId",
                principalTable: "M01C",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_K11T_M01C_M01CId",
                table: "K11T",
                column: "M01CId",
                principalTable: "M01C",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M01C_B03T_B3Id",
                table: "M01C",
                column: "B3Id",
                principalTable: "B03T",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M02T_M01C_M01CID",
                table: "M02T",
                column: "M01CID",
                principalTable: "M01C",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_K02T_M01C_M01CId",
                table: "K02T");

            migrationBuilder.DropForeignKey(
                name: "FK_K11T_M01C_M01CId",
                table: "K11T");

            migrationBuilder.DropForeignKey(
                name: "FK_M01C_B03T_B3Id",
                table: "M01C");

            migrationBuilder.DropForeignKey(
                name: "FK_M02T_M01C_M01CID",
                table: "M02T");

            migrationBuilder.DropIndex(
                name: "IX_M02T_M01CID",
                table: "M02T");

            migrationBuilder.DropIndex(
                name: "IX_M01C_B3Id",
                table: "M01C");

            migrationBuilder.DropIndex(
                name: "IX_K02T_M01CId",
                table: "K02T");

            migrationBuilder.RenameColumn(
                name: "B3Id",
                table: "M01C",
                newName: "B3CD");
        }
    }
}
