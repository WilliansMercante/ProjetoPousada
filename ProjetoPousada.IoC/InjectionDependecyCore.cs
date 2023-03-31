using Microsoft.Extensions.DependencyInjection;

using ProjetoPousada.Aplicacao.Config;
using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro;
using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.Dominio.Services;
using ProjetoPousada.Dominio.Services.Interfaces;
using ProjetoPousada.Infra;
using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.Infra.Repositories.Cadastro;
using ProjetoPousada.Infra.Repositories.Config;

namespace ProjetoPousada.IoC
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddRepositories(services);
            AddApplication(services);
            AddService(services);
        }

        private static void AddApplication(IServiceCollection services)
        {
            #region Segurança

            services.AddScoped<IMenuApp, MenuApp>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();

            #endregion

            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IEnderecoApp, EnderecoApp>();
            services.AddScoped<ITelefoneApp, TelefoneApp>();
            services.AddScoped<ISexoApp, SexoApp>();
        }

        private static void AddService(IServiceCollection services)
        {
            services.AddScoped<IAutenticarService, AutenticarService>();
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


            #region Cadastro

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();

            #endregion




            services.AddScoped<IUnitOfWork<ProjetoPousadaContext>, UnitOfWork<ProjetoPousadaContext>>();
        }
    }

}
