﻿using System.ComponentModel.DataAnnotations;

namespace NSE.Identidade.API.Models
{
    public class UserViewModels
    {
        public class UsuarioRegistro
        {
            [Required(ErrorMessage = "O campos {0} é obrigatorio")]
            [EmailAddress(ErrorMessage = "O campo {0} está em formato invalido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campos {0} é obrigatorio")]
            [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public string Senha { get; set; }
            [Required(ErrorMessage = "O campos {0} é obrigatorio")]
            [Compare("Senha", ErrorMessage = "As senhas não conferem")]
            public string SenhaConfirmacao { get; set; }
        }
        public class UsuarioLogin
        {

            [Required(ErrorMessage = "O campos {0} é obrigatorio")]
            [EmailAddress(ErrorMessage = "O campo {0} está em formato invalido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campos {0} é obrigatorio")]
            [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public string Senha { get; set; }
        }


        public class UsuarioRespostaLogin
        {
            public string AccessToken { get; set; }
            public double ExpiresIn { get; set; }
            public UsuarioToken UsuarioToken { get; set; }
        }

        public class UsuarioToken
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public IEnumerable<UsuarioClaim> Claims { get; set; }
        }

        public class UsuarioClaim
        {
            public string Value { get; set; }
            public string Type { get; set; }            
        }
    }
}