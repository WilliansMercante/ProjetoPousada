using Microsoft.Extensions.DependencyInjection;

using ProjetoPousada.Aplicacao.Config;
using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Config.Interfaces;
using ProjetoPousada.Infra;
using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.Infra.Repositories.Config;

namespace ProjetoPousada.IoC
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
            AddApplication(services);
        }

        private static void AddApplication(IServiceCollection services)
        {
            #region Segurança

            services.AddScoped<IMenuApp, MenuApp>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();

            #endregion
        }

        private static void AddServices(IServiceCollection services)
        {
        }

        private static void AddRepositories(IServiceCollection services)
        {
            #region Configuracao

            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Mensagem

            services.AddScoped<IUnitOfWork<ConfiguracaoContext>, UnitOfWork<ConfiguracaoContext>>();

            #endregion

            services.AddScoped<IUnitOfWork<ProjetoPousadaContext>, UnitOfWork<ProjetoPousadaContext>>();
        }
    }

}
