using FluentValidator.Validation;
using GalinhaCaipira.Domain.Validators;
using EmailValidator = GalinhaCaipira.Domain.Validators.EmailValidator;

namespace GalinhaCaipira.Domain.ValueObjects
{
    public class Email : ValidatorBase<Email, EmailValidator>, IValidatable
    {
        private Email()
        {
        }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public string Endereco { get; private set; }

        public void Validate()
        {
            base.Validate(this);
        }
    }
}