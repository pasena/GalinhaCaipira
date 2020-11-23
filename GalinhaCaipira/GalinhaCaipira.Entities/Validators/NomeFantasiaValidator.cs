using FluentValidation;
using GalinhaCaipira.Domain.ValueObjects;

namespace GalinhaCaipira.Domain.Validators
{
    public class NomeFantasiaValidator : AbstractValidator<NomeFantasia>
    {
        public NomeFantasiaValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage("Nome é obrigatório!");
            RuleFor(r => r.Nome).Length(300).WithMessage("O tamanho máximo é de 300 carácteres!");
        }
    }
}