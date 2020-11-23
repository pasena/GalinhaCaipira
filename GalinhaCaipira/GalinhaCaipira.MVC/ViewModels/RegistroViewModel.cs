using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalinhaCaipira.MVC.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(150, ErrorMessage = "No máximo {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(150, ErrorMessage = "No máximo {1} caracteres!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(300, ErrorMessage = "No máximo {1} caracteres!")]
        public string NomeGranja { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(150, ErrorMessage = "No máximo {1} caracteres!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(150, ErrorMessage = "No máximo {1} caracteres!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "A senha deve conter no minimo 8 caracteres e no máximo 15, sendo um número um letra maiuscula e um caracter especial.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(150, ErrorMessage = "No máximo {1} caracteres!")]
        [Compare(nameof(Senha), ErrorMessage = "A confirmação da senha diverge da senha.")]
        public string ConfirmarSenha { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Obrigatório")]
        public bool TermosAceitos { get; set; }

    }
}