using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.Repositories.Context;
using GalinhaCaipira.Repositories.Interfaces;
using System;
using System.Linq;

namespace GalinhaCaipira.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BDGalinhaCaipiraContext contexto;

        public UsuarioRepository()
        {
            contexto = new BDGalinhaCaipiraContext();
        }

        public UsuarioRepository(BDGalinhaCaipiraContext contexto)
        {
            this.contexto = contexto;
        }

        public void Incluir(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public Usuario ObterPorId(int id)
        {
            return contexto.Usuarios.SingleOrDefault(u => u.UsuarioId == id);
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            return contexto.Usuarios.SingleOrDefault(s => s.Email.Endereco == email);
        }
    }
}