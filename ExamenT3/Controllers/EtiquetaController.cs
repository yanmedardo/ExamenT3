using ExamenFinal.Models;
using ExamenFinal.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Controllers
{
    public class EtiquetaController : Controller
    {
        private IEtiquetaRepository etiquetaRepository;

        public EtiquetaController(IEtiquetaRepository etiquetaRepository)
        {
            this.etiquetaRepository = etiquetaRepository;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Etiqueta etiqueta)
        {
            etiquetaRepository.Registrar(etiqueta);
            return RedirectToAction("Index", "Nota");
        }
    }
}
