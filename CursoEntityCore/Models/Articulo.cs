using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    [Table("Tbl_Articulo")]
    public class Articulo
    {
        [Key]
        public int Articulo_Id { get; set; }
        
        [Column("Titulo")]
        public string TituloArticulo { get; set; }

        public string Descripcion { get; set; }
        
        public string Fecha { get; set; }
    }
}
