using AutoMapper;

using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.ViewModel.Cadastro;
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
                Cadastro(cfg);
            });

            return config.CreateMapper();
        }

        private static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuItemEntity, MenuViewModel>().ReverseMap();
            cfg.CreateMap<UsuarioEntity, UsuarioViewModel>().ReverseMap();
            cfg.CreateMap<GrupoEntity, GrupoViewModel>().ReverseMap();
        }

        private static void Cadastro(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ClienteEntity, ClienteViewModel>().ReverseMap();
            cfg.CreateMap<EnderecoEntity, EnderecoViewModel>().ReverseMap();
            cfg.CreateMap<TipoEnderecoEntity, TipoEnderecoViewModel>().ReverseMap();
            cfg.CreateMap<TelefoneEntity, TelefoneViewModel>().ReverseMap();
            cfg.CreateMap<TipoTelefoneEntity, TipoTelefoneViewModel>().ReverseMap();
            cfg.CreateMap<SexoEntity, SexoViewModel>().ReverseMap();
        }

    }
}
