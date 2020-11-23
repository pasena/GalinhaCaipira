using FluentValidator;
using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.Repositories.Interfaces;
using GalinhaCaipira.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Services
{
    public class ControleAcessoService : IControleAcessoService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public ControleAcessoService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario.Senha.ValidarSenha(senha))
            {
                return usuario;
            }

            return null;
        }

        public Usuario RegistrarUsuario(Usuario usuario, string nomeGranja)
        {
            ValidarRegistroUsuario(usuario);

            if (usuario.Valid)
            {
                usuario.AdicionarGranja(nomeGranja);
                usuarioRepository.Incluir(usuario);
            }

            return usuario;
        }

        private void ValidarRegistroUsuario(Usuario usuario)
        {
            if (usuarioRepository.ObterUsuarioPorEmail(usuario.Email.Endereco) != null)
            {
                usuario.AddNotification("Email", "Email já cadastrado!");
            }

            usuario.Validate();
        }
    }
}
