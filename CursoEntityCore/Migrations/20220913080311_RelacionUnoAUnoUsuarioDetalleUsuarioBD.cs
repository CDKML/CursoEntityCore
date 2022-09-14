using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class RelacionUnoAUnoUsuarioDetalleUsuarioBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuario_Id",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DetalleUsuario_Id",
                table: "Usuario",
                column: "DetalleUsuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "Usuario",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuario",
                principalColumn: "DetalleUsuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DetalleUsuario_Id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DetalleUsuario_Id",
                table: "Usuario");
        }
    }
}
