using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Entidades.Log;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Infra.Mappings.Cadastro;
using ProjetoPousada.Infra.Mappings.Log;

namespace ProjetoPousada.Infra.Contexts
{
    public sealed class ProjetoPousadaContext : DbContext, IUnitOfWork<ProjetoPousadaContext>
    {
        public ProjetoPousadaContext(DbContextOptions<ProjetoPousadaContext> options) : base(options)
        {

        }

        #region Cadastro

        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<TelefoneEntity> Telefone { get; set; }
        public DbSet<TipoEnderecoEntity> TipoEndereco { get; set; }
        public DbSet<TipoTelefoneEntity> TipoTelefone { get; set; }
        public DbSet<SexoEntity> Sexo { get; set; }

        #endregion

        #region Log
        public DbSet<LogEntity> Log { get; set; }

        #endregion

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());
            modelBuilder.ApplyConfiguration(new TipoEnderecoMapping());
            modelBuilder.ApplyConfiguration(new TipoTelefoneMapping());
            modelBuilder.ApplyConfiguration(new SexoMapping());

            modelBuilder.ApplyConfiguration(new LogMapping());

            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
