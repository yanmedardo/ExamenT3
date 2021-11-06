using ExamenT3.Controllers;
using ExamenT3.Models;
using ExamenT3.Repository;
using ExamenT3.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT3Tests.Unitarias
{
    class NotaControllerTests
    {

        [Test]
        public void Index()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            notaRepository.Setup(x => x.Listar("", 0)).Returns(new List<Nota>());
            etiquetaRepository.Setup(x => x.Listar()).Returns(new List<Etiqueta>());

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Index();
            Assert.IsInstanceOf<ViewResult>(resultado);
        }

        [Test]
        public void Detalle()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            notaRepository.Setup(x => x.ObtenerPorId(1)).Returns(new Nota());

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Detalle(1);
            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsInstanceOf<Nota>((resultado as ViewResult).Model);
        }

        [Test]
        public void Registrar()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            var nota = new Nota()
            {
                Titulo = "Titulo",
                Contenido = "Contenido"
            };

            int[] etiquetas = new int[] { 1, 2, 3 };

            notaRepository.Setup(x => x.Registrar(nota));
            notaRepository.Setup(x => x.AsignarEtiquetas(nota, etiquetas));

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Registrar(nota, etiquetas);
            Assert.IsInstanceOf<RedirectToActionResult>(resultado);
        }

        [Test]
        public void RegistrarVista()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            etiquetaRepository.Setup(x => x.Listar()).Returns(new List<Etiqueta>());

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Registrar();
            Assert.IsInstanceOf<ViewResult>(resultado);
        }

        [Test]
        public void Editar()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            var nota = new Nota()
            {
                Titulo = "Titulo",
                Contenido = "Contenido"
            };

            int[] etiquetas = new int[] { 1, 2, 3 };

            notaRepository.Setup(x => x.Editar(1, nota));
            notaRepository.Setup(x => x.AsignarEtiquetas(nota, etiquetas));

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Editar(1, nota, etiquetas);
            Assert.IsInstanceOf<RedirectToActionResult>(resultado);
        }

        [Test]
        public void EditarVista()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            notaRepository.Setup(x => x.ObtenerPorId(1)).Returns(new Nota());
            etiquetaRepository.Setup(x => x.Listar()).Returns(new List<Etiqueta>());

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Editar(1);
            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsInstanceOf<Nota>((resultado as ViewResult).Model);
        }

        [Test]
        public void Eliminar()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            notaRepository.Setup(x => x.Eliminar(1));

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Eliminar(1);
            Assert.IsInstanceOf<RedirectToActionResult>(resultado);
        }

        [Test]
        public void Compartir()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            int[] usuarios = new int[] { 1, 2, 3 };

            notaRepository.Setup(x => x.Compartir(1, usuarios));

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Compartir(1, usuarios);
            Assert.IsInstanceOf<RedirectToActionResult>(resultado);
        }

        [Test]
        public void CompartirVista()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            var usuarios = new List<Usuario>()
            {
                new Usuario() {
                    Id= 1,
                    Username = "admin",
                    Password = "1234"
                },
                new Usuario() {
                    Id= 2,
                    Username = "user1",
                    Password = "1234"
                },
                new Usuario() {
                    Id= 3,
                    Username = "user2",
                    Password = "1234"
                },
            };

            var usuarioAdmin = new Usuario()
            {
                Id = 1,
                Username = "admin",
                Password = "1234"
            };

            notaRepository.Setup(x => x.ObtenerPorId(1)).Returns(new Nota());
            usuarioRepository.Setup(x => x.Listar()).Returns(usuarios);
            cookieService.Setup(x => x.GetUserLogged()).Returns(usuarioAdmin);

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.Compartir(1);
            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsInstanceOf<Nota>((resultado as ViewResult).Model);
        }

        [Test]
        public void CompartirConmigo()
        {
            var notaRepository = new Mock<INotaRepository>();
            var etiquetaRepository = new Mock<IEtiquetaRepository>();
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var cookieService = new Mock<ICookieAuthService>();

            notaRepository.Setup(x => x.ListarCompartidasConmigo()).Returns(new List<Nota>());

            var controller = new NotaController(notaRepository.Object, etiquetaRepository.Object, usuarioRepository.Object, cookieService.Object);

            var resultado = controller.CompartidoConmigo();
            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsInstanceOf<List<Nota>>((resultado as ViewResult).Model);
        }
    }
}
