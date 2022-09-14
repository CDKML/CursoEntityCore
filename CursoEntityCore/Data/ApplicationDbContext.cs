using CursoEntityCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
        }

        //Escribir modelos
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Articulo> Articulo { get; set; }

        public DbSet<DetalleUsuario> DetalleUsuario { get; set; }
        
        public DbSet<Etiqueta> Etiqueta { get; set; }
        
        public DbSet<ArticuloEtiqueta> ArticuloEtiqueta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.Etiqueta_Id, ae.Articulo_Id });

            //Siembra de datos en este método
            var categoria7 = new Categoria() { Categoria_Id = 41, Nombre = "Categoría 7", FechaCreacion = new DateTime(2022, 09, 13), Activo = true};
            var categoria8 = new Categoria() { Categoria_Id = 42, Nombre = "Categoría 8", FechaCreacion = new DateTime(2022, 09, 14), Activo = false};
            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria8});

            base.OnModelCreating(modelBuilder);
        }
    }
}
