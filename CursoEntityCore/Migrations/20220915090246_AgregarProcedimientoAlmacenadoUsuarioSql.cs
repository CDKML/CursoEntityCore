using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class AgregarProcedimientoAlmacenadoUsuarioSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.SpObtenerUsuarioId @idUsuario INT AS
                                    SET NOCOUNT ON;
                                    SELECT * FROM dbo.Usuario u
                                    WHERE u.Id = @idUsuario
                                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
