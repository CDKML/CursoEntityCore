using CursoEntityCore.Data;
using CursoEntityCore.Models;
using CursoEntityCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEntityCore.Controllers
{
    public class ArticulosController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public ArticulosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            //Opción 1 sin datos relacionados (solo trae el ID de la categoría)
            List<Articulo> listaArticulos = _contexto.Articulo.ToList();

            foreach (var articulo in listaArticulos)
            {
                //Opción 2: carga manual (se generan muchas consultas SQL, no es muy eficiente si cargamos más propiedades)
                //articulo.Categoria = _contexto.Categoria.FirstOrDefault(c => c.Categoria_Id == articulo.Categoria_Id);
                //Opción 3: carga explícita (Explicit loading)
                _contexto.Entry(articulo).Reference(c => c.Categoria).Load();
            }
            return View(listaArticulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _contexto.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _contexto.Articulo.Add(articulo);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            //Para que al retornar la vista por algún error, también retorne la lista de categorías
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _contexto.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            return View(articuloCategorias);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _contexto.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            articuloCategorias.Articulo = _contexto.Articulo.FirstOrDefault(c => c.Articulo_Id == id);
            if(articuloCategorias == null)
            {
                return NotFound();
            }

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ArticuloCategoriaVM articuloVM)
        {
            if (articuloVM.Articulo.Articulo_Id == 0)
            {
                return View(articuloVM.Articulo);
            }
            else
            {
                _contexto.Articulo.Update(articuloVM.Articulo);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var articulo = _contexto.Articulo.FirstOrDefault(c => c.Articulo_Id == id);
            _contexto.Articulo.Remove(articulo);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
