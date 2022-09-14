﻿using CursoEntityCore.Data;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEntityCore.Controllers
{
    public class EtiquetasController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public EtiquetasController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            //Consulta inicial con todos los datos
            List<Etiqueta> listaEtiquetas = _contexto.Etiqueta.ToList();
            return View(listaEtiquetas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _contexto.Etiqueta.Add(etiqueta);
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

            var etiqueta = _contexto.Etiqueta.FirstOrDefault(u => u.Etiqueta_Id == id);
            return View(etiqueta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _contexto.Etiqueta.Update(etiqueta);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(etiqueta);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var etiqueta = _contexto.Etiqueta.FirstOrDefault(u => u.Etiqueta_Id == id);
            _contexto.Etiqueta.Remove(etiqueta);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
