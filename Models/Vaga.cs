using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homedelas.Models
{
    public class Vaga
    {
        [Key, Required]
        public int Id_Vagas {get; set;}

        [Required] //Chave estrangeira Cadastro_Vaga
        private int Cadastro_VagaId_cadastro_vaga {get; set;}
        public Cadastro_Vaga Cadastro_Vaga {get; set;}
    }
}