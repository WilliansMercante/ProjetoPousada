using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Config
{
	public sealed class MenuItemRepository : RepositoryBase<MenuItemEntity, ConfiguracaoContext>, IMenuItemRepository
	{
		public MenuItemRepository(ConfiguracaoContext context) : base(context)
		{
		}

		public IEnumerable<MenuItemEntity> ListarPorGrupo(int idGrupo)
		{
			var lstItens = _context.PermissaoMenuItem
									.Include(p => p.MenuItem)
									.Where(p => p.IdGrupo.Equals(idGrupo) && p.MenuItem != null && !p.MenuItem.IdMenuItemSuperior.HasValue)
									.Select(p => p.MenuItem)
									.ToList();

			foreach (var item in lstItens)
				item.SubItens = ObterFilhos(item.Id, idGrupo) as ICollection<MenuItemEntity>;

			return lstItens;
		}

		private IEnumerable<MenuItemEntity> ObterFilhos(int idMenuItemSuperior, int idGrupo)
		{
			var lstItens = _context.PermissaoMenuItem
								   .Include(p => p.MenuItem)
								   .Where(p => p.IdGrupo.Equals(idGrupo) && p.MenuItem.IdMenuItemSuperior.HasValue && p.MenuItem.IdMenuItemSuperior.Equals(idMenuItemSuperior))
								   .Select(p => p.MenuItem)
								   .ToList();

			foreach (var item in lstItens)
				item.SubItens = ObterFilhos(item.Id, idGrupo) as ICollection<MenuItemEntity>;

			return lstItens;
		}
	}
}
