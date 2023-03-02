using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Dominio.Interfaces.Config.Interfaces
{
    public interface IMenuItemRepository : IRepositoryBase<MenuItemEntity>
    {
        IEnumerable<MenuItemEntity> ListarPorGrupo(int idGrupo);
    }
}
