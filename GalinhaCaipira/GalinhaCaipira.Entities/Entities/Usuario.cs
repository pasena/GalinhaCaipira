using FluentValidator.Validation;
using GalinhaCaipira.Domain.Validators;
using GalinhaCaipira.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace GalinhaCaipira.Domain.Entities
{
    public class Usuario : EntityBase<Usuario, UsuarioValidator>, IValidatable
    {
        private Usuario()
        {
        }

        public Usuario(string primeiroNome, string sobrenome, string email, string senha)
        {
            Nome = new Nome(primeiroNome, sobrenome);
            Email = new Email(email);
            Senha = new Senha(senha);
            
            Ativo = true;
            Granjas = new List<Granja>();
        }

        public int UsuarioId { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public bool Ativo { get; private set; }
        public virtual ICollection<Granja> Granjas { get; private set; }

        public void AdicionarGranja(string nomeGranja)
        {
            Granjas.Add(new Granja(nomeGranja));
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Validate()
        {
            base.Validate(this);
        }
    }
}