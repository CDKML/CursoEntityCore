using CursoEntityCore.Data;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CursoEntityCore.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        
        public CategoriasController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            //Consulta inicial con todos los datos
            List<Categoria> listaCategorias = _contexto.Categoria.ToList();

            //Consulta filtrando por fecha
            //DateTime fechaComparacion = new DateTime(2022, 09, 13);
            //List<Categoria> listaCategorias = _contexto.Categoria.Where(f => f.FechaCreacion >= fechaComparacion).OrderByDescending(f => f.FechaCreacion).ToList();
            //return View(listaCategorias);

            //Selecciona columnas específicas
            //var categorias = _contexto.Categoria.Where(n => n.Nombre == "Test 5").Select(n => n).ToList();
            //List<Categoria> listaCategorias = _contexto.Categoria.ToList();
            //var listaCategorias = _contexto.Categoria
            //    .GroupBy(c => new { c.Activo })
            //    .Select(c => new { c.Key, Count = c.Count() }).ToList();

            //var listaCategorias = _contexto.Categoria.FromSqlRaw("SELECT * FROM Categoria where nombre like 'categoría%'").ToList();

            //Interpolación de string
            //var id = 39;
            //var categoria = _contexto.Categoria.FromSqlRaw($"SELECT * FROM Categoria WHERE categoria_id = {id}").ToList();
            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contexto.Categoria.Add(categoria);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion2()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 2; i++)
            {
                categorias.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
                //_contexto.Categoria.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
            }

            _contexto.Categoria.AddRange(categorias);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion5()
        {
            List<Categoria> categorias = new List<Categoria>();

            for (int i = 0; i < 5; i++)
            {
                categorias.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });

                _contexto.Categoria.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
            }

            _contexto.Categoria.AddRange(categorias);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult VistaCrearMultipleOpcionFormulario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearMultipleOpcionFormulario()
        {
            string categoriasForm = Request.Form["Nombre"];
            var listaCategorias = from val in categoriasForm.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries) select (val);
            List<Categoria> categorias = new List<Categoria>();

            foreach (var categoria in listaCategorias)
            {
                categorias.Add(new Categoria {
                    Nombre = categoria
                });
            }
            _contexto.Categoria.AddRange(categorias);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null)
            {
                return View();
            }

            var categoria = _contexto.Categoria.FirstOrDefault(c => c.Categoria_Id == id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contexto.Categoria.Update(categoria);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var categoria = _contexto.Categoria.FirstOrDefault(c => c.Categoria_Id == id);
            _contexto.Categoria.Remove(categoria);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple2()
        {
            IEnumerable<Categoria> categorias = _contexto.Categoria.OrderByDescending(c => c.Categoria_Id).Take(2);
            _contexto.Categoria.RemoveRange(categorias);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple5()
        {
            IEnumerable<Categoria> categorias = _contexto.Categoria.OrderByDescending(c => c.Categoria_Id).Take(5);
            _contexto.Categoria.RemoveRange(categorias);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Ejecución diferida
        //Las consultas EF Core no se ejecutan cuando son creadas. Se ejecutan según los siguientes escenarios
        //más información: https://docs.microsoft.com/es-es/dotnet/framework/data/adonet/ef/language-reference/query-execution
        [HttpGet]
        public void EjecucionDiferida()
        {
            //1-Cuando se hace una iteración sobre ellos. Ejemplo:
            var categorias = _contexto.Categoria;

            foreach (var categoria in categorias)
            {
                var nombreCat = "";
                nombreCat = categoria.Nombre;
            }

            //2-Cuando se llama a cualquiera de los métodos: ToDictionary, ToList, ToArray
            var categorias2 = _contexto.Categoria.ToList();

            foreach (var categoria in categorias2)
            {
                var nombreCat = "";
                nombreCat = categoria.Nombre;
            }

            //3-Cuando se llama cualquier método que retorna un solo objeto:
            //First, Single, COunt, Max, entre otros
            var categorias3 = _contexto.Categoria;
            var totalCategorias = categorias3.Count();

            var totalCategorias2 = _contexto.Categoria.Count();

            var test = "";
        }

        public void TestIEnumerable()
        {
            //1- Código con IEnumerable
            IEnumerable<Categoria> listaCategorias = _contexto.Categoria;
            var categoriasActivas = listaCategorias.Where(a => a.Activo == true).ToList();
            //2- Consulta resultante
            /*
             * SELECT [c].[Categoria_Id], [c].[Activo]. [c].[FechaCreacion], [c].[Nombre]
             * FROM [Categoria] AS[c]
            */
            //3- El filtro del where se aplica en memoria del lado del cliente
        }

        public void TestIQueryable()
        {
            //1- Código con IQueryable
            //IQueryable hereda de IEnumerable
            //Todo lo que se puede hacer con IEnumerable se puede hacer con IQueryable
            IQueryable<Categoria> listaCategorias = _contexto.Categoria;
            var categoriasActivas = listaCategorias.Where(a => a.Activo == true).ToList();
            //2- Consulta resultante
            /*
             * SELECT [c].[Categoria_Id], [c].[Activo]. [c].[FechaCreacion], [c].[Nombre]
             * FROM [Categoria] AS[c]
             * WHERE[c].[Activo] = CAST (1 AS bit)
            */
        }
    }
}
