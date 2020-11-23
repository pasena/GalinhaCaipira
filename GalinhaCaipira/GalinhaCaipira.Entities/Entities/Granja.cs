using FluentValidator.Validation;
using GalinhaCaipira.Domain.Validators;
using GalinhaCaipira.Domain.ValueObjects;

namespace GalinhaCaipira.Domain.Entities
{
    public class Granja : EntityBase<Granja, GranjaValidator>, IValidatable
    {
        private Granja()
        {
        }

        public Granja(string nomeFantasia)
        {
            NomeFantasia = new NomeFantasia(nomeFantasia);
        }

        public int GranjaId { get; private set; }

        public NomeFantasia NomeFantasia { get; private set; }

        public int UsuarioId { get; private set; }

        public virtual Usuario Dono { get; private set; }

        public void Validate()
        {
            base.Validate(this);
        }
    }
}