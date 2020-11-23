using FluentValidator.Validation;
using GalinhaCaipira.Domain.Validators;

namespace GalinhaCaipira.Domain.ValueObjects
{
    public class NomeFantasia : ValidatorBase<NomeFantasia, NomeFantasiaValidator>, IValidatable
    {
        private NomeFantasia()
        {
        }

        internal NomeFantasia(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public void Validate()
        {
            base.Validate(this);
        }
    }
}