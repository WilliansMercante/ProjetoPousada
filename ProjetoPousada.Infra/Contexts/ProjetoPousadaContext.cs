using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Infra.Mappings.Cadastro;

namespace ProjetoPousada.Infra.Contexts
{
    public sealed class ProjetoPousadaContext : DbContext, IUnitOfWork<ProjetoPousadaContext>
    {
        public ProjetoPousadaContext(DbContextOptions<ConfiguracaoContext> options) : base(options)
        {

        }

        #region Cadastro

        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<TelefoneEntity> Telefone { get; set; }
        public DbSet<TipoEnderecoEntity> TipoEndereco { get; set; }
        public DbSet<TipoTelefoneEntity> TipoTelefone { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());
            modelBuilder.ApplyConfiguration(new TipoEnderecoMapping());
            modelBuilder.ApplyConfiguration(new TipoTelefoneMapping());

            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
