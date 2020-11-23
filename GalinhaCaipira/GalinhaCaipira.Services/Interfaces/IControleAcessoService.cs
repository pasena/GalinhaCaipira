using FluentValidator;
using FluentValidator.Validation;
using GalinhaCaipira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GalinhaCaipira.Services.Interfaces
{
    public interface IControleAcessoService
    {
        Usuario RegistrarUsuario(Usuario usuario, string nomeGranja);
        Usuario Login(string email, string senha);
    }
}
