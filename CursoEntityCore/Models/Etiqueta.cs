using System.ComponentModel.DataAnnotations;

namespace CursoEntityCore.Models
{
    public class Etiqueta
    {
        [Key]
        [Display(Name = "Id de etiqueta")]
        public int Etiqueta_Id { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
