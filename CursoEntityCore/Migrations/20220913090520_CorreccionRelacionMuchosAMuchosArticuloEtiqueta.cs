using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class CorreccionRelacionMuchosAMuchosArticuloEtiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id1",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id1",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id1",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropIndex(
                name: "IX_ArticuloEtiqueta_Etiqueta_Id1",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropColumn(
                name: "Articulo_Id1",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropColumn(
                name: "Etiqueta_Id1",
                table: "ArticuloEtiqueta");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id",
                table: "ArticuloEtiqueta",
                column: "Etiqueta_Id",
                principalTable: "Etiqueta",
                principalColumn: "Etiqueta_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id",
                principalTable: "Tbl_Articulo",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.AddColumn<int>(
                name: "Articulo_Id1",
                table: "ArticuloEtiqueta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Etiqueta_Id1",
                table: "ArticuloEtiqueta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id1",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Etiqueta_Id1",
                table: "ArticuloEtiqueta",
                column: "Etiqueta_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id1",
                table: "ArticuloEtiqueta",
                column: "Etiqueta_Id1",
                principalTable: "Etiqueta",
                principalColumn: "Etiqueta_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id1",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id1",
                principalTable: "Tbl_Articulo",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
