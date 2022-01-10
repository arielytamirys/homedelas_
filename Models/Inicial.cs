using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homedelas.Models
{
    public class Inicial
    {
        [Key, Required]
        public int Id_Inicial {get; set;}

        [Required]
        public string Buscar {get; set;} 

        [Required] //Chave estrangeira Vaga
        private int VagaId_vaga {get; set;}
        public Vaga Vagas {get; set;}
    }
}