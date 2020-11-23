using System;
using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalinhaCaipira.Tests.Entities
{
    [TestClass]
    public class UsuarioTests
    {
        [TestMethod]
        public void CriarUsuario_SemNomeESobreNome_DeveRetornarNotificacao()
        {
            Usuario usuario = new Usuario(string.Empty, string.Empty, "email@email.com.br", "A12bcdef@");
            usuario.Validate();
            Assert.AreEqual(false, usuario.Valid, "Não deve ser possível criar usuário sem nome e sobrenome");
        }

        [TestMethod]
        public void CriarUsuario_ComNomeESobreNome_NaoDeveRetornarNotificacao()
        {
            Usuario usuario = new Usuario("Nome", "Sobrenome", "email@email.com.br", "A12bcdef@");
            usuario.Validate();
            Assert.AreEqual(true, usuario.Valid, "Deve ser possível criar usuário com nome e sobrenome");
        }

        [TestMethod]
        public void DesativarUsuario_AoDesativarUsuario_NaoDeveRetornarNotificacao()
        {
            Usuario usuario = new Usuario("Nome", "Sobrenome", "email@email.com.br", "A12bcdef@");
            usuario.Desativar();
            Assert.AreEqual(false, usuario.Ativo, "Não foi possível desativar o usuário");
        }
    }
}
