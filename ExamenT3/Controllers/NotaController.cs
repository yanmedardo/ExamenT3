using ExamenT3.Models;
using ExamenT3.Repository;
using ExamenT3.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Controllers
{
    [Authorize]
    public class NotaController : Controller
    {
        private INotaRepository notaRepository;
        private IEtiquetaRepository etiquetaRepository;
        private IUsuarioRepository usuarioRepository;
        private ICookieAuthService cookieService;

        public NotaController(INotaRepository notaRepository, IEtiquetaRepository etiquetaRepository, IUsuarioRepository usuarioRepository, ICookieAuthService cookie)
        {
            this.notaRepository = notaRepository;
            this.etiquetaRepository = etiquetaRepository;
            this.usuarioRepository = usuarioRepository;
            this.cookieService = cookie;
        }
        
        [HttpGet]
        public IActionResult Index(string buscar = "", int etiqueta = 0)
        {
            var notas = notaRepository.Listar(buscar, etiqueta);
            foreach (var nota in notas)
            {
                if (nota.Contenido.Length > 50)
                {
                    nota.Contenido = nota.Contenido.Substring(0, 50);
                }
            }
            ViewBag.Buscar = buscar;
            ViewBag.Etiqueta = etiqueta;
            ViewBag.Etiquetas = etiquetaRepository.Listar();
            return View(notas);
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var nota = notaRepository.ObtenerPorId(id);
            return View(nota);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.Etiquetas = etiquetaRepository.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Nota nota, int[] Etiquetas)
        {
            notaRepository.Registrar(nota);
            notaRepository.AsignarEtiquetas(nota, Etiquetas);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var nota = notaRepository.ObtenerPorId(id);
            ViewBag.Etiquetas = etiquetaRepository.Listar();
            return View(nota);
        }

        [HttpPost]
        public IActionResult Editar(int id, Nota nota, int[] Etiquetas)
        {
            notaRepository.Editar(id, nota);
            notaRepository.AsignarEtiquetas(nota, Etiquetas);
            return RedirectToAction("Detalle", new { id = id });
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            notaRepository.Eliminar(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Compartir(int id)
        {
            var nota = notaRepository.ObtenerPorId(id);
            var usuarios = usuarioRepository.Listar();
            usuarios.Remove(cookieService.GetUserLogged());
            ViewBag.Usuarios = usuarios;
            return View(nota);
        }

        [HttpPost]
        public IActionResult Compartir(int id, int[] Usuarios)
        {
            notaRepository.Compartir(id, Usuarios);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CompartidoConmigo()
        {
            var notas = notaRepository.ListarCompartidasConmigo();
            return View(notas);
        }
    }
}
