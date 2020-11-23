using FluentValidator.Validation;
using GalinhaCaipira.Domain.Validators;

namespace GalinhaCaipira.Domain.ValueObjects
{
    public class Nome : ValidatorBase<Nome, NomeValidator>, IValidatable
    {
        private Nome()
        {
        }

        internal Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public override string ToString()
        {
            return $"{PrimeiroNome} {Sobrenome}";
        }

        public void Validate()
        {
            base.Validate(this);
        }
    }
}