using Homedelas.Models;
using Microsoft.EntityFrameworkCore;

namespace Homedelas.Data
{
    public class InicialContext : DbContext 
    {
        public InicialContext(DbContextOptions<InicialContext> opt) : base(opt) {

        }
        public DbSet<Inicial> Inicials {get; set;}
        public DbSet<Vaga> Vagas {get; set;}
        public DbSet<Cadastro_Vaga> Cadastro_Vagas {get; set;}
        public DbSet<Login> Logins {get; set;}
        public DbSet<Contato> Contatos {get; set;}
    }
}