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
        [Required]
        [MaxLength(20)]
        public string TituloArticulo { get; set; }

        [Required]
        public string Descripcion { get; set; }
        
        public string Fecha { get; set; }
    }
}
