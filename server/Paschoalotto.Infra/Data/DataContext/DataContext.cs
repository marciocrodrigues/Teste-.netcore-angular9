using Microsoft.EntityFrameworkCore;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Infra.Data.EntidadesMapeamento;

namespace Paschoalotto.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Parametrizacao> Parametrizacoes { get; set; }
        public DbSet<Divida> Dividas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new ParametrizacaoMapeamento());
            modelBuilder.ApplyConfiguration(new DividaMapeamento());
        }
    }
}
