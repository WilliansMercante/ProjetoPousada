using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Dominio.Interfaces.Config
{
    public interface IMenuItemRepository : IRepositoryBase<MenuItemEntity>
    {
        IEnumerable<MenuItemEntity> ListarPorGrupo(int idGrupo);
    }
}
