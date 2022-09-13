using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class LlaveForaneaCategoriaArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categoria",
                newName: "Categoria_Id");

            migrationBuilder.AddColumn<int>(
                name: "Categoria_Id",
                table: "Tbl_Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Articulo_Categoria_Id",
                table: "Tbl_Articulo",
                column: "Categoria_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Articulo_Categoria_Categoria_Id",
                table: "Tbl_Articulo",
                column: "Categoria_Id",
                principalTable: "Categoria",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Articulo_Categoria_Categoria_Id",
                table: "Tbl_Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Articulo_Categoria_Id",
                table: "Tbl_Articulo");

            migrationBuilder.DropColumn(
                name: "Categoria_Id",
                table: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "Categoria_Id",
                table: "Categoria",
                newName: "Id");
        }
    }
}
