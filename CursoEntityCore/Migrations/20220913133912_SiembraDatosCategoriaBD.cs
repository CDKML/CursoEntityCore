using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class SiembraDatosCategoriaBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Categoria_Id", "Activo", "FechaCreacion", "Nombre" },
                values: new object[] { 41, true, new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoría 7" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Categoria_Id", "Activo", "FechaCreacion", "Nombre" },
                values: new object[] { 42, false, new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoría 8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Categoria_Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Categoria_Id",
                keyValue: 42);
        }
    }
}
