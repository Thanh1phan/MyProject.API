using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyProject.API.Migrations.Data
{
    /// <inheritdoc />
    public partial class edit_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_K11T",
                table: "K11T");

            migrationBuilder.DropPrimaryKey(
                name: "PK_K02T",
                table: "K02T");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "K11T");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "K02T");

            migrationBuilder.AddPrimaryKey(
                name: "PK_K11T",
                table: "K11T",
                column: "M01CId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_K02T",
                table: "K02T",
                columns: new[] { "Seq", "M01CId" });

            migrationBuilder.InsertData(
                table: "B03T",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canon", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sony", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "K02T",
                columns: new[] { "M01CId", "Seq", "CreateDate", "UpdateDate", "Url" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 1, null, null, "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/44d7d59b-297e-43fb-1ed7-c402c3fce500/storedata" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), 1, null, null, "https://kyma.vn/StoreData/images/Product/may-anh-sony-alpha-ilce6700-a6700-body.jpg" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 2, null, null, "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/b9749b99-0ce3-42e3-c1ac-25cfb033b100/storedata" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), 2, null, null, "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/1fb59980-67f3-49cb-4060-1eb1dc10f400/storedata" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 3, null, null, "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/ab09dca0-c22d-46df-a563-99fb11d08f00/storedata" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), 3, null, null, "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/4e622b29-115b-4ab3-cf7c-9816f1d2fb00/storedata" }
                });

            migrationBuilder.InsertData(
                table: "K11T",
                columns: new[] { "M01CId", "CreateDate", "UpdateDate", "ZIBAIKA", "ZOBAIKA" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), null, null, 18700000m, 17000000m },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), null, null, 36300000m, 33000000m }
                });

            migrationBuilder.InsertData(
                table: "M01C",
                columns: new[] { "Id", "B3CD", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canon EOS R6 Mark II Kit RF24-105mm F4 L IS USM", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sony Alpha ILCE-6700 / A6700 Body", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_K11T",
                table: "K11T");

            migrationBuilder.DropPrimaryKey(
                name: "PK_K02T",
                table: "K02T");

            migrationBuilder.DeleteData(
                table: "B03T",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "B03T",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"));

            migrationBuilder.DeleteData(
                table: "K02T",
                keyColumns: new[] { "M01CId", "Seq" },
                keyValues: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 1 });

            migrationBuilder.DeleteData(
                table: "K02T",
                keyColumns: new[] { "M01CId", "Seq" },
                keyValues: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), 1 });

            migrationBuilder.DeleteData(
                table: "K02T",
                keyColumns: new[] { "M01CId", "Seq" },
                keyValues: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 2 });

            migrationBuilder.DeleteData(
                table: "K02T",
                keyColumns: new[] { "M01CId", "Seq" },
                keyValues: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), 2 });

            migrationBuilder.DeleteData(
                table: "K02T",
                keyColumns: new[] { "M01CId", "Seq" },
                keyValues: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 3 });

            migrationBuilder.DeleteData(
                table: "K02T",
                keyColumns: new[] { "M01CId", "Seq" },
                keyValues: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), 3 });

            migrationBuilder.DeleteData(
                table: "K11T",
                keyColumn: "M01CId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "K11T",
                keyColumn: "M01CId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"));

            migrationBuilder.DeleteData(
                table: "M01C",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "M01C",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "K11T",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "K02T",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_K11T",
                table: "K11T",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_K02T",
                table: "K02T",
                column: "Id");
        }
    }
}
