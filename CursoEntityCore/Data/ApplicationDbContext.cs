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

            //Fluent API: relación de uno a uno entre Usuario y DetalleUsuario
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.DetalleUsuario)
                .WithOne(u => u.Usuario).HasForeignKey<Usuario>("DetalleUsuario_Id");

            //Fluent API: relación de uno a muchos entre Categoria y Articulo
            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Categoria)
                .WithMany(a => a.Articulo).HasForeignKey(a => a.Categoria_Id);

            //Fluent API: relación de muchos a muchos entre Articulo y Etiqueta
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.Etiqueta_Id, ae.Articulo_Id });
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasOne(a => a.Articulo)
                .WithMany(a => a.ArticuloEtiqueta).HasForeignKey(a => a.Articulo_Id);
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasOne(a => a.Etiqueta)
                .WithMany(a => a.ArticuloEtiqueta).HasForeignKey(a => a.Etiqueta_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
