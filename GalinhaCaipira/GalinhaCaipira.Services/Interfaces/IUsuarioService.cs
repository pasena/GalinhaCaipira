using GalinhaCaipira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario ObterUsuarioPorLogin(string login);
        Usuario ObterUsuarioPorEmail(string email);
    }
}
