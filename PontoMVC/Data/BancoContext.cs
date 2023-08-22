using Microsoft.EntityFrameworkCore;
using PontoMVC.Data.Mapping;
using PontoMVC.Models;
using System.Reflection;

namespace PontoMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options) //uma injeção diferente: options é um tipode DbContextOptions<BancoContext> e vai ser passado através do base para o banco de dados
        {
        }

        public DbSet<PontoModel> Pontos { get; set; } //Quais as tabelas do be banco de dados
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
