using CursoEntityCore.Data;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;

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
            List<Categoria> listaCategorias = _contexto.Categoria.ToList();
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
    }
}
