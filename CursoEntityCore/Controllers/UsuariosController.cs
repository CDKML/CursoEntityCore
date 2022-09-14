using CursoEntityCore.Data;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Editar(Guid? id)
        {
            if (id == null)
            {
                return View();
            }

            var usuario = _contexto.Usuario.FirstOrDefault(u => u.Id == id);
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
        public IActionResult Borrar(Guid? id)
        {
            var usuario = _contexto.Usuario.FirstOrDefault(u => u.Id == id);
            _contexto.Usuario.Remove(usuario);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detalle(Guid? id)
        {
            if(id == null)
            {
                return View();
            }

            var usuario = _contexto.Usuario.Include(d => d.DetalleUsuario).FirstOrDefault(u => u.Id == id);
            if(usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarDetalle(Usuario usuario)
        {
            if (usuario.DetalleUsuario.DetalleUsuario_Id == 0)
            {
                //Creamos los detalles para ese usuario
                _contexto.DetalleUsuario.Add(usuario.DetalleUsuario);
                _contexto.SaveChanges();

                //Después de crear el detalle del usuario, obtenemos el usuario de la base de datos
                //y actualizamos el campo "DetalleUsuario_Id"
                var usuarioBd = _contexto.Usuario.FirstOrDefault(u => u.Id == usuario.Id);
                usuarioBd.DetalleUsuario_Id = usuario.DetalleUsuario.DetalleUsuario_Id;
                _contexto.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
