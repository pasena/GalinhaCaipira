using FluentValidation;
using GalinhaCaipira.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(r => r.Endereco)
                .NotEmpty().WithMessage("Endereço do email é obrigatório")
                .EmailAddress().WithMessage("Endereço do email é inválido");
        }
    }
}
