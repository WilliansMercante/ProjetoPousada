using AutoMapper;

using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Config
{
    public sealed class MenuApp : IMenuApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuApp(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }


        public IEnumerable<MenuViewModel> ListarPorGrupo(int idGrupo)
        {
            var lstItensMenuPrincipalEntity = _menuItemRepository.ListarPorGrupo(idGrupo);
            var lstItensMenuPrincipalVM = _mapper.Map<IEnumerable<MenuItemEntity>, IEnumerable<MenuViewModel>>(lstItensMenuPrincipalEntity);
            return lstItensMenuPrincipalVM;
        }
    }
}
