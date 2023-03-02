using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Config.Interfaces
{
    public interface IUsuarioApp
    {
        UsuarioViewModel Autenticar(string cpf, string senha);
    }
}
