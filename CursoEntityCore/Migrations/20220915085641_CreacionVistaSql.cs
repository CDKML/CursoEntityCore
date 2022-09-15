using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class CreacionVistaSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[ObtenerCategorias]
                                    AS
                                    SELECT Categoria_Id, Nombre, FechaCreacion, Activo
                                    FROM dbo.Categoria
                                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
