using GalinhaCaipira.Domain.Entities;

namespace GalinhaCaipira.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        void Incluir(Usuario usuario);
        Usuario ObterPorId(int id);
        Usuario ObterUsuarioPorEmail(string email);
    }
}