using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Config.Interfaces
{
    public interface IMenuApp
    {
        IEnumerable<MenuViewModel> ListarPorGrupo(int idGrupo);
    }
}
