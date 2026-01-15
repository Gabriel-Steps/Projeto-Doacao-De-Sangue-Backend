using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeSangue.Core.Entities;
using System.Reflection;

namespace ProjetoDoacaoDeSangue.Infra
{
    public class ProjetoDbContext : DbContext
    {
        public ProjetoDbContext(DbContextOptions<ProjetoDbContext> options) : base(options) { }

        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EstoqueSangue> EstoqueSangues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
