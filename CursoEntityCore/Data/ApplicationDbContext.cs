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
            //modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.Etiqueta_Id, ae.Articulo_Id });

            //Siembra de datos en este método
            //var categoria7 = new Categoria() { Categoria_Id = 41, Nombre = "Categoría 7", FechaCreacion = new DateTime(2022, 09, 13), Activo = true};
            //var categoria8 = new Categoria() { Categoria_Id = 42, Nombre = "Categoría 8", FechaCreacion = new DateTime(2022, 09, 14), Activo = false};
            //modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria8});

            //Fluent API para Categoría
            modelBuilder.Entity<Categoria>().HasKey(c => c.Categoria_Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<Categoria>().Property(c => c.FechaCreacion).HasColumnType("date");

            //Fluent API para Artículo
            modelBuilder.Entity<Articulo>().HasKey(a => a.Articulo_Id);
            modelBuilder.Entity<Articulo>().Property(a => a.TituloArticulo).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Articulo>().Property(a => a.Descripcion).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Articulo>().Property(a => a.Fecha).HasColumnType("date");
            //Fluent API nombre de tabla y nombre columna
            modelBuilder.Entity<Articulo>().ToTable("Tbl_Articulo");
            modelBuilder.Entity<Articulo>().Property(a => a.TituloArticulo).HasColumnName("Titulo");

            //Fluent API para Usuario
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>().Ignore(u => u.Edad);

            //Fluent API para DetalleUsuario
            modelBuilder.Entity<DetalleUsuario>().HasKey(du => du.DetalleUsuario_Id);
            modelBuilder.Entity<DetalleUsuario>().Property(du => du.Cedula).IsRequired();

            //Fluent API para Etiqueta
            modelBuilder.Entity<Etiqueta>().HasKey(e => e.Etiqueta_Id);
            modelBuilder.Entity<Etiqueta>().Property(e => e.Fecha).HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }
    }
}
