using FluentValidation;
using GalinhaCaipira.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public class NomeValidator : AbstractValidator<Nome>
    {
        public NomeValidator()
        {
            RuleFor(r => r.PrimeiroNome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(r => r.Sobrenome).NotEmpty().WithMessage("Sobrenome é obrigatório");
        }
    }
}
