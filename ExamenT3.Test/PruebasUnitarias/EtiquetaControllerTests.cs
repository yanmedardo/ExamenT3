using ExamenT3.Controllers;
using ExamenT3.Models;
using ExamenT3.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT3Tests.Unitarias
{
    class EtiquetaControllerTests
    {
        [Test]
        public void RegistrarVista()
        {
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var controller = new EtiquetaController(etiquetaRepository.Object);

            var resultado = controller.Registrar();
            Assert.IsInstanceOf<ViewResult>(resultado);
        }

        [Test]
        public void Registrar()
        {
            var etiquetaRepository = new Mock<IEtiquetaRepository>();

            var etiqueta = new Etiqueta()
            {
                Nombre = "Nueva etiqueta"
            };

            etiquetaRepository.Setup(x => x.Registrar(etiqueta));

            var controller = new EtiquetaController(etiquetaRepository.Object);
            var resultado = controller.Registrar(etiqueta);

            Assert.IsInstanceOf<RedirectToActionResult>(resultado);
        }
    }
}
