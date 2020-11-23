using FluentValidator.Validation;
using GalinhaCaipira.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.ValueObjects
{
    public class Senha : ValidatorBase<Senha, SenhaValidator>, IValidatable
    {
        private Senha()
        {

        }

        internal Senha(string chave)
        {
            Chave = chave;
            Criptografar();
        }

        [NotMapped]
        public string Chave { get; private set; }

        public byte[] HashChave { get; private set; }

        public byte[] HashSalt { get; private set; }

        private void Criptografar()
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                HashSalt = hmac.Key;
                HashChave = hmac.ComputeHash(Encoding.UTF8.GetBytes(Chave));
            }
        }

        public bool ValidarSenha(string senha)
        {
            byte[] hashSenha;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                hmac.Key = HashSalt;
                hashSenha = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }

            return hashSenha.SequenceEqual(HashChave);
        }

        public void Validate()
        {
            base.Validate(this);
        }
    }
}
