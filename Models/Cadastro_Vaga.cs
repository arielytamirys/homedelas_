using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homedelas.Models
{
    public class Cadastro_Vaga
    {
        [Key, Required]
        public int Id_Cadastro_Vaga {get; set;}

        [Required]
        public string CNPJ {get; set;}

        [Required]
        public string Empresa {get; set;}

        [Required]
        public string Responsavel {get; set;}

        [Required]
        public string Setor {get; set;}

        [Required]
        public string Vaga {get; set;}

        [Required]
        public string Descricao {get; set;}
    
        [Required] //Chave estrangeira Login
        private int LoginId_login {get; set;}
        public Login Login {get; set;}

        [Required] //Chave estrangeira Contato
        private int ContatoId_contato {get; set;}
        public Contato Contato {get; set;}

    }
}