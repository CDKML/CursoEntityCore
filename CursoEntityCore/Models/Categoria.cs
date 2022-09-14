using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Id de categoría")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Categoria_Id { get; set; }
        
        //[DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        [Required]
        public string Nombre { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Estado")]
        public bool Activo { get; set; }
        
        [Display(Name = "Artículo")]
        public List<Articulo> Articulo { get; set; }
        
    }
}
