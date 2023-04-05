using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces
{
    public interface ITipoEnderecoApp
    {
        IEnumerable<TipoEnderecoViewModel> Listar();
    }
}
