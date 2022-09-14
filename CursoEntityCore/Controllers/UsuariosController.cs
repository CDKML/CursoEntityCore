using CursoEntityCore.Data;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEntityCore.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public UsuariosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            //Consulta inicial con todos los datos
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList();
            return View(listaUsuarios);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var usuario = _contexto.Usuario.FirstOrDefault(c => c.DetalleUsuario_Id == id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var usuario = _contexto.Usuario.FirstOrDefault(c => c.DetalleUsuario_Id == id);
            _contexto.Usuario.Remove(usuario);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
