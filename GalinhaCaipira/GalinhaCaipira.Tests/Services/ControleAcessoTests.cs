using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GalinhaCaipira.Repositories.Interfaces;
using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.Services;
using Castle.Components.DictionaryAdapter.Xml;
using FluentValidator;
using GalinhaCaipira.Services.Interfaces;
using System.Linq;
using GalinhaCaipira.Domain.ValueObjects;

namespace GalinhaCaipira.Tests.Services
{

    [TestClass]
    public class ControleAcessoTests
    {
        readonly Mock<IUsuarioRepository> usuarioRepositoy;
        readonly IControleAcessoService controleAcessoService;

        public ControleAcessoTests()
        {
            usuarioRepositoy = new Mock<IUsuarioRepository>();
            controleAcessoService = new ControleAcessoService(usuarioRepositoy.Object);
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            usuarioRepositoy
                   .Setup(s => s.ObterUsuarioPorEmail("pa.sena@gmail.com"))
                   .Returns(new Usuario("Paulo Alex", "Sena", "pa.sena@gmail.com", "1235"));

            usuarioRepositoy
                .Setup(s => s.ObterUsuarioPorEmail("email@email.com.br"))
                .Returns(new Usuario("Paulo Alex", "Sena", "pa.sena@gmail.com", "1235"));
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Registrar_ComEmailJaCadastrado_DeveRetornarNotificacao_EmailJaCadastrado()
        {
            Usuario usuario = new Usuario("Usuario", "Novo", "pa.sena@gmail.com", "1235");

            // Act
            usuario = controleAcessoService.RegistrarUsuario(usuario, "granja");

            // Assert
            Assert.AreNotEqual(0, usuario.Notifications.Count, 
                "Notificação de email já cadastrado não implementada");

            Assert.IsTrue(usuario.Notifications.Any(a => a.Message == "Email já cadastrado!"), 
                "Mensagem de notificação do email já cadastrado deveria ser: Email já cadastrado!");
        }

        [TestMethod]
        public void Registrar_ComDadosValidos_NaoDeveRetornarNotificacao()
        {
            Usuario usuario = new Usuario("Usuario", "Novo", "usuario.novo@gmail.com", "1235");

            // Act
            usuario = controleAcessoService.RegistrarUsuario(usuario, "granja");

            Assert.AreEqual(0, usuario.Notifications.Count, "Não foi possível registrar um usuário com dados válidos");
        }

        [TestMethod]
        public void Registrar_ComDadosInvalidos_DeveRetornarNotificacao()
        {
            Usuario usuario = new Usuario("", "", "usuario.novo", "");

            // Act
            usuario = controleAcessoService.RegistrarUsuario(usuario, "granja");

            Assert.AreNotEqual(0, usuario.Notifications.Count, "Foi possível registrar um usuário com dados inválidos");
        }

        //[TestMethod]
        //public void Login_WithoutUserName_MustReturnNotification()
        //{
        //    // Act
        //    var usuario = controleAcessoService.Login("", "password");

        //    // Assert
        //    Assert.AreEqual(false, controleAcessoService.Valid, "Username required validation not implemented");
        //    // Assert.AreEqual(1, controleAcessoService.Notifications.First(), "Username required validation not implemented");
        //}

        //[TestMethod]
        //public void Login_WithoutPassword_MustReturnNotification()
        //{
        //    List<Notification> notifications = controleAcessoService.Login("userName", "");

        //    // Assert
        //    Assert.AreEqual(1, notifications.Count, "Password is required");
        //}

        //public void Login_WithWrongUserName_MustReturnNotification()
        //{

        //}
    }
}
