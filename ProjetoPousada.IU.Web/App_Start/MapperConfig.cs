using AutoMapper;

using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.IU.Web.App_Start
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Configuracoes(cfg);
            });

            return config.CreateMapper();
        }

        private static void Configuracoes(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuItemEntity, MenuViewModel>();
        }
    }
}
