using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        
        public string Nombre { get; set; }

        public string Email { get; set; }
        
        public string Direccion { get; set; }

        [NotMapped]
        public int Edad { get; set; }

    }
}
