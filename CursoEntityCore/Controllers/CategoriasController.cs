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
    }
}
