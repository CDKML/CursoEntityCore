using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class RelacionMuchosAMuchosArticuloEtiquetaBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    Articulo_Id = table.Column<int>(type: "int", nullable: false),
                    Etiqueta_Id = table.Column<int>(type: "int", nullable: false),
                    Articulo_Id1 = table.Column<int>(type: "int", nullable: false),
                    Etiqueta_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.Etiqueta_Id, x.Articulo_Id });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id1",
                        column: x => x.Etiqueta_Id1,
                        principalTable: "Etiqueta",
                        principalColumn: "Etiqueta_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id1",
                        column: x => x.Articulo_Id1,
                        principalTable: "Tbl_Articulo",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id1",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Etiqueta_Id1",
                table: "ArticuloEtiqueta",
                column: "Etiqueta_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");
        }
    }
}
