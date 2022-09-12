using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    [Table("Tbl_Articulo")]
    public class Articulo
    {
        public int ArticuloId { get; set; }
        
        [Column("Articulo")]
        public string TituloArticulo { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Fecha { get; set; }
    }
}
