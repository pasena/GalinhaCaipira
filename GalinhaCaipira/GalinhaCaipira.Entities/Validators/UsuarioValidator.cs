using FluentValidation;
using FluentValidation.Validators;
using GalinhaCaipira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(r => r.Nome).SetValidator(new NomeValidator());
            RuleFor(r => r.Email).SetValidator(new EmailValidator());
            RuleFor(r => r.Senha).SetValidator(new SenhaValidator());
        }
    }
}
