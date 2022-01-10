using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homedelas.Models
{
    public class Login
    {
        [Key, Required]
        public int Id_Login {get; set;}

        [Required]
        public string Email {get; set;}
       
        [Required]
        public string Senha {get; set;}

        [Required]
        public string Confirmar {get; set;}
    }
}