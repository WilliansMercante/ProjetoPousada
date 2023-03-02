using AutoMapper;

using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Mapper
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Config(cfg);
                ;
            });

            return config.CreateMapper();
        }

        private static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuItemEntity, MenuViewModel>().ReverseMap();
            cfg.CreateMap<UsuarioEntity, UsuarioViewModel>().ReverseMap();
            cfg.CreateMap<GrupoEntity, GrupoViewModel>().ReverseMap();

        }
    }
}
