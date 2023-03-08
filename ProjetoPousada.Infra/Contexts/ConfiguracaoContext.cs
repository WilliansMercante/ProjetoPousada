using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Entidades.Log;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Infra.Mappings.Config;
using ProjetoPousada.Infra.Mappings.Log;

namespace ProjetoPousada.Infra.Contexts
{
    public sealed class ConfiguracaoContext : DbContext, IUnitOfWork<ConfiguracaoContext>
    {
        public ConfiguracaoContext(DbContextOptions<ConfiguracaoContext> options) : base(options)
        {

        }

        #region Config

        public DbSet<MenuItemEntity> MenuItem { get; set; }
        public DbSet<PermissaoMenuItemEntity> PermissaoMenuItem { get; set; }
        public DbSet<ParametroEntity> Parametro { get; set; }
        public DbSet<ParametroGrupoEntity> ParametroGrupo { get; set; }        

        #endregion


        #region Log

        public DbSet<LogEntity> Log { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuItemMapping());
            modelBuilder.ApplyConfiguration(new PermissaoMenuItemMapping());
            modelBuilder.ApplyConfiguration(new ParametroMapping());
            modelBuilder.ApplyConfiguration(new ParametroGrupoMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());

            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
