using ExamenFinal.Models;
using ExamenFinal.Repository;
using ExamenFinal.Service;
using CalidadT2Tests.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Tests.Unitarias
{
    class AuthControllerTests
    {
        [Test]
        public void Login()
        {
            var usuario = new Usuario();
            usuario.Password = "admin";
            usuario.Username = "admin";

            var cookMock = new Mock<ICookieAuthService>();
            var userMock = new Mock<IUsuarioRepository>();

            userMock.Setup(o => o.FindUser(usuario.Username, usuario.Password)).Returns(usuario);

            var authCont = new AuthController(userMock.Object, cookMock.Object);

            var resultado = authCont.Login("admin", "1234");

            Assert.IsInstanceOf<ViewResult>(resultado);
        }

        [Test]
        public void Registrar()
        {
            var userMock = new Mock<IUsuarioRepository>();

            var authMock = new Mock<ICookieAuthService>();

            userMock.Setup(o => o.Registrar("admin", "1234"));

            var controller = new AuthController(userMock.Object, authMock.Object);
            var result = controller.Registrar("admin", "1234");

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
