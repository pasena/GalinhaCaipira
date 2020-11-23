using FluentValidation;
using GalinhaCaipira.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public class SenhaValidator : AbstractValidator<Senha>
    {
        public SenhaValidator()
        {
            RuleFor(r => r.Chave)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres, contendo letras maiúsculas, números e caracteres especiais!")
                .Must(m => m.Any(a => char.IsUpper(a))).WithMessage("A senha deve ter no mínimo 8 caracteres, contendo letras maiúsculas, números e caracteres especiais!")
                .Must(m => m.Any(a => char.IsDigit(a))).WithMessage("A senha deve ter no mínimo 8 caracteres, contendo letras maiúsculas, números e caracteres especiais!")
                .Must(m => m.Any(a => !char.IsLetterOrDigit(a))).WithMessage("A senha deve ter no mínimo 8 caracteres, contendo letras maiúsculas, números e caracteres especiais!");
        }
    }
}
